using IconEntry.Constant;
using IconEntry.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

using Xamarin.Forms;

namespace IconEntry
{
	public class Page1 : ContentPage
    {
        CustomEntry Email;
        PasswordControl PasswordEntry;

        public Page1 ()
		{
            Email = new CustomEntry { Padding = new Thickness(0, 40, 0, 0), Placeholder = "Email", Keyboard = Keyboard.Text, HeaderImage = Constants.Images.Email, MaxLength = 25 };
            Email.BubbledFocused += Email_BubbledFocused;

            PasswordEntry = new PasswordControl {
                IsPassword=true,Margin=new Thickness(0,20,0,0),HeaderIcon=Constant.Constants.Images.Password
                ,Placeholder="password"
            };

            Content = new StackLayout { Children = {Email,PasswordEntry } };
        }

        private void Email_BubbledFocused(object arg1, FocusEventArgs arg2)
        {
            if (!string.IsNullOrEmpty(Email.Text))
            {
                

                if (IsVaildEmail(Email.Text))
                {
                    Email.IsSuccces = true;
                }
                else
                {
                    Email.IsNormalFeildsSuccces = false;
                    Email.SetWarining("Invlid Email Address test mirage");
                }

            }
            else
                Email.SetWarining("Please Fill the Email Field");
        }
        
        public bool IsVaildEmail(string mail)
        {

            try
            {
                MailAddress userMail = new MailAddress(mail);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
    }
}