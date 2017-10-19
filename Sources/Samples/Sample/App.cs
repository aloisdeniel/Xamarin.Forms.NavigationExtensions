﻿using System;

using Xamarin.Forms;
using Sample.Navigation;

namespace Sample
{
	public class App : Application
	{
		public App()
		{
			Locator.Service = new WebService();

			var tabbedPage = new TabbedPage();

			tabbedPage.Children.Add(new NavigationPage(new AlbumsPage()) { Title="Albums" });
			tabbedPage.Children.Add(new NavigationPage(new UsersPage()) { Title="Users" });

			MainPage = tabbedPage;
		}

		public readonly TimeSpan RestorationTimeSpan = TimeSpan.FromHours(1);

		protected override async void OnStart()
		{
			var tabbedPage = this.MainPage as TabbedPage;

			await tabbedPage.Children[0].Navigation.RestoreAsync("Albums", RestorationTimeSpan);
			await tabbedPage.Children[1].Navigation.RestoreAsync("Users", RestorationTimeSpan);
		}

		protected override void OnSleep()
		{
			var tabbedPage = this.MainPage as TabbedPage;

			tabbedPage.Children[0].Navigation.Store("Albums");
			tabbedPage.Children[1].Navigation.Store("Users");
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

