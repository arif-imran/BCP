//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomActivityIndicator.xaml.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomActivityIndicator.xaml.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// Custom activity indicator.
    /// </summary>
    public partial class CustomActivityIndicator : ContentView
    {
        /// <summary>
        /// The fade out.
        /// </summary>
        private bool fadeOut = true;

        /// <summary>
        /// The max opacity.
        /// </summary>
        private double maxOpacity = 1;

        /// <summary>
        /// The minimum opacity.
        /// </summary>
        private double minOpacity = 0.1;

        /// <summary>
        /// The binking delay.
        /// </summary>
        private uint binkingDelay = 500;

        /// <summary>
        /// The fade out delay.
        /// </summary>
        private uint fadeOutDelay = 500;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Controls.CustomActivityIndicator"/> class.
        /// </summary>
        public CustomActivityIndicator()
        {
            this.IsVisible = false;
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.Forms.Controls.CustomActivityIndicator"/> is running.
        /// </summary>
        /// <value><c>true</c> if is running; otherwise, <c>false</c>.</value>
        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { this.SetValue(IsRunningProperty, value); }
        }

        /// <summary>
        /// The is running property.
        /// </summary>
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create("IsRunning", typeof(bool), typeof(CustomActivityIndicator), false, BindingMode.TwoWay, null, propertyChanged: OnIsRunningChanged);

        /// <summary>
        /// Ons the is running changed.
        /// </summary>
        /// <param name="bindable">Bindable object.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        public static void OnIsRunningChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomActivityIndicator)bindable).OnIsRunningChanged((bool)oldValue, (bool)newValue);
        }

        /// <summary>
        /// Ons the is running changed.
        /// </summary>
        /// <param name="oldValue">If set to <c>true</c> old value.</param>
        /// <param name="newValue">If set to <c>true</c> new value.</param>
        private void OnIsRunningChanged(bool oldValue, bool newValue)
        {
            if (newValue && !oldValue)
            {
                this.IsVisible = true;
                this.LoaderContainer.Opacity = 1;
                ////this.LoadingTextLabel.Animate("labelanimation", new Animation((double obj) =>
                ////{
                ////    LoadingTextLabel.Opacity = FadeOut ? obj : maxOpacity + minOpacity - obj;
                ////}, maxOpacity, minOpacity, Easing.CubicInOut), 0, binkingDelay, null, (arg1, arg2) =>
                ////{
                ////    FadeOut = !FadeOut;
                ////}, () =>
                ////{
                ////    return true;
                ////});
            }
            else
            {
                ////this.LoadingTextLabel.AbortAnimation("labelanimation");
                this.LoaderContainer.Animate("containeranimation", new Animation((double obj) =>
                {
                    this.LoaderContainer.Opacity = obj;
                }, 
                                                                                 this.LoaderContainer.Opacity, 0, Easing.CubicInOut), 0, this.fadeOutDelay, null, (arg1, arg2) =>
                {
                    this.IsVisible = false; 
                }, () =>

                {
                    return false;
                });
            }
            //// System.Diagnostics.Debug.WriteLine("The old value is " + Convert.ToString(oldValue) + " and the new value is " + Convert.ToString(newValue));
        }
    }
}
