﻿using System;
using XForms.Toolkit.Mvvm;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XForms.Toolkit.Services;
using System.Threading.Tasks;

namespace XForms.Toolkit.Sample
{
	public class MainViewModel : ViewModel
	{
		public MainViewModel ()
		{
			SpeakCommand = new RelayCommand (() => {
				DependencyService.Get<ITextToSpeechService>().Speak("Hello from XForms Toolkit");
			});
			Items = new ObservableCollection<string> ();
			for (int i = 0; i < 10; i++) {
				Items.Add(string.Format("item {0}",i));
			}
		
		}

		public void StartTimer(){
			Device.StartTimer (new TimeSpan(6000), () => {
				DeviceTimerInfo ="This text was updated using the Device Timer";
				return true;
			});
		
		}


		public string DeviceOS {
			get{ 
				return string.Format("Your device OS: {0}", Device.OS.ToString());
			}
		}

		public string DeviceIdiom {
			get{ 
				return string.Format("Your device Idiom: {0}", Device.Idiom.ToString ());
			}
		}
		public string DeviceClassInfo {
			get{ 
				return "The Device class allows you  to access the Main UI thread, so you can marshal your code easily.";
			}
		}
		private string _deviceUIThreadInfo = string.Empty;
		public string DeviceUIThreadInfo{
			get{
				return _deviceUIThreadInfo;
			}
			set{ 
				_deviceUIThreadInfo = value;
				NotifyPropertyChanged ("DeviceUIThreadInfo");
			}
		}
		private string _deviceTimerInfo = string.Empty;
		public string DeviceTimerInfo{
			get{
				return _deviceTimerInfo;
			}
			set{ 
				_deviceTimerInfo = value;
				NotifyPropertyChanged ("DeviceTimerInfo");
			}
		}

		private ObservableCollection<string> _items= null;
		public ObservableCollection<string> Items{
			get{
				return _items;
			}
			 set{ 
				_items = value;
				NotifyPropertyChanged ("Items");
			}
		}

	
		private RelayCommand _speakCommand= null;
		public RelayCommand SpeakCommand{
			get{
				return _speakCommand;
			}
			private set{ 
				_speakCommand = value;
			}
		}

		private RelayCommand<string> _searchCommand;
		public RelayCommand<string> SearchCommand {
			get{ return _searchCommand ?? new RelayCommand<string> (
				obj => {


				}, obj => !string.IsNullOrEmpty (obj)); }
		}


	}
}

