using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using DeepAI;
using System.IO;

namespace Rairi
{
    public partial class LostPage : ContentPage
    {
        public LostPage()
        {
            InitializeComponent();
        }

        private async void UploadButton_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not currently support this functionality", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImage == null)
            {
                await DisplayAlert("Error", "Could not get the image, please try again.", "Ok");
                return;
            }

            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }

        private async void UploadButton2_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not currently support this functionality", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImage2 == null)
            {
                await DisplayAlert("Error", "Could not get the image, please try again.", "Ok");
                return;
            }

            selectedImage2.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            DeepAI_API api = new DeepAI_API("cff6094b-1163-47f0-96c8-96965a790c36");
            StandardApiResponse resp = api.callStandardApi("image-similarity", new
            {
                image1 = File.OpenRead(selectedImage2.Source.ToString()),
                image2 = File.OpenRead("C:\\path\\to\\your\\file.jpg"),
            });

            await DisplayAlert("Message",api.objectAsJsonString(resp),"Ok");
        }
    }
}
