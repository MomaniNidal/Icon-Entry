using IconEntry.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace IconEntry.Controls
{
    class PasswordControl : ContentView, INotifyPropertyChanged
    {

        #region Control

        public event Action<object, FocusEventArgs> PasswordEvent;


        Grid GridEntry;

        Image imgEntry;

        BorderLessEntry txt;

        Label lblWariningMessage;

        StackLayout statxt;

        BoxView boxView;

        Label lblStatus;

        Image imgViewPassword;

        TapGestureRecognizer tgrViewPassword;
        #endregion

        #region Properties

        public event Action<object, FocusEventArgs> BubbledFocused;

        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(PasswordControl), defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty HeaderIconProperty = BindableProperty.Create(nameof(HeaderIcon), typeof(string), typeof(PasswordControl), defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(PasswordControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (PasswordControl)bindable;
            matEntry.txt.Placeholder = (string)newval;

        });


        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(PasswordControl), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (PasswordControl)bindable;
            matEntry.txt.IsPassword = (bool)newVal;
        });


        public static BindableProperty ViewPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(PasswordControl), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (PasswordControl)bindable;
            matEntry.txt.IsPassword = (bool)newVal;
        });

        public static BindableProperty IsRightProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(PasswordControl), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (PasswordControl)bindable;
            bool isRight = (bool)newVal;

            if (isRight)
            {
                matEntry.txt.FlowDirection = FlowDirection.LeftToRight;
                matEntry.txt.HorizontalTextAlignment = TextAlignment.End;

            }

        });


        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(PasswordControl), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (PasswordControl)bindable;
            matEntry.txt.Keyboard = (Keyboard)newVal;
        });

        public static BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(PasswordControl), defaultValue: 25, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (PasswordControl)bindable;
            matEntry.txt.MaxLength = (int)newVal;
        });

        public static BindableProperty StatusLabelProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(PasswordControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (PasswordControl)bindable;
            matEntry.lblStatus.IsVisible = true;
            matEntry.lblStatus.Text = (string)newval;

        });

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }

        }

        public string HeaderIcon
        {

            get
            {
                return (string)GetValue(HeaderIconProperty);
            }
            set
            {
                SetValue(HeaderIconProperty, value);
            }
        }

        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }
   
        public string Status
        {
            get
            {
                return (string)GetValue(StatusLabelProperty);
            }
            set
            {
                SetValue(StatusLabelProperty, value);
            }
        }

        public bool IsRight
        {
            get
            {
                return (bool)GetValue(IsRightProperty);
            }
            set
            {
                SetValue(IsRightProperty, value);
            }
        }
        public bool ViewPassword
        {
            get
            {
                return (bool)GetValue(ViewPasswordProperty);
            }
            set
            {
                SetValue(ViewPasswordProperty, value);
            }
        }


        public PasswordControl()
        {
            tgrViewPassword = new TapGestureRecognizer { };
            tgrViewPassword.Tapped += TgrViewPassword_Tapped1;

            BuildUI();
            //Set Default Max Length 
            if (MaxLength == 0)
                MaxLength = 25;

            DisAllowedCharacter = "<,>,/,'";
            SplittiedDisAllowedCharacters = DisAllowedCharacter.Split(",".ToCharArray()).ToList();


            imgEntry.BindingContext = this;
            txt.BindingContext = this;
            lblStatus.BindingContext = this;

        }

        private void TgrViewPassword_Tapped1(object sender, EventArgs e)
        {
            if(IsPassword)
            {
                IsPassword = false;
                imgViewPassword.Source = Constants.Images.HidePassword;

            }
            else
            {
                IsPassword = true;
                imgViewPassword.Source = Constants.Images.ViewPassword;


            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }

        public List<string> SplittiedDisAllowedCharacters { get; set; }

        public string DisAllowedCharacter { get; set; }

        #endregion

        public void BuildUI()
        {

            GridEntry = new Grid { };
            GridEntry.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            GridEntry.RowDefinitions.Add(new RowDefinition { Height = 1 });
            GridEntry.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            GridEntry.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            lblWariningMessage = new Label { FontSize = 7, TextColor = Color.FromHex("#f15b40"), Margin = new Thickness(10, 0, 10, 0), IsVisible = false };
            lblStatus = new Label { TextColor = Color.Orange, IsVisible = false, VerticalTextAlignment = TextAlignment.Center, FontSize = 10 };

            boxView = new BoxView { IsVisible = true, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 0, 10, 0) ,Color=Color.LightGray };

            statxt = new StackLayout { Orientation = StackOrientation.Horizontal, Padding = new Thickness(10, 0, 10, 0) };

            imgEntry = new Image { WidthRequest = 20, HeightRequest = 20 };
            imgEntry.SetBinding(Image.SourceProperty, "HeaderIcon");
            imgViewPassword = new Image { WidthRequest = 30, HeightRequest = 30,Source= Constants.Images.ViewPassword };
            imgViewPassword.GestureRecognizers.Add(tgrViewPassword);
            txt = new BorderLessEntry { HorizontalOptions = LayoutOptions.FillAndExpand, PlaceholderColor = Color.Gray, TextColor = Color.Black };
            if (Device.RuntimePlatform == Device.Android)
                txt.FontSize = 15;
            else
                txt.FontSize = 9;


            txt.SetBinding(Entry.TextProperty, "Text");
            txt.Unfocused += Txt_Unfocused;
            txt.TextChanged += Txt_TextChanged;


            statxt.Children.Add(imgEntry);
            statxt.Children.Add(txt);
            statxt.Children.Add(imgViewPassword);

            GridEntry.Children.Add(statxt, 0, 0);
            Grid.SetColumnSpan(statxt, 10);
            GridEntry.Children.Add(boxView, 0, 1);
            Grid.SetColumnSpan(boxView, 10);
            GridEntry.Children.Add(lblWariningMessage, 0, 2);
            Grid.SetColumnSpan(lblWariningMessage, 10);

        
            this.Content = GridEntry;
            if (Device.RuntimePlatform == Device.iOS)
                this.HeightRequest = 52;
            else
                this.HeightRequest = 65;


        }
        private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (string ch in SplittiedDisAllowedCharacters)
            {
                if (txt.Text != null)
                {
                    if (txt.Text.Contains(ch))
                    {
                        this.Text = e.OldTextValue;
                        break;
                    }
                }
            }


        }

        private void Txt_Unfocused(object sender, FocusEventArgs e)
        {
            BubbledFocused?.Invoke(sender, e);
        }

        public void SetWarining(string text)
        {
           
            boxView.IsVisible = true;
            boxView.Color = Color.FromHex("#f15b40");
            lblStatus.IsVisible = false;
            lblWariningMessage.IsVisible = true;
            lblWariningMessage.Text = text;
        }

        public void SetFieldEmpty()
        {

            lblStatus.IsVisible = false;
            boxView.IsVisible = false;
            lblWariningMessage.IsVisible = false;
        

        }

    }
}
