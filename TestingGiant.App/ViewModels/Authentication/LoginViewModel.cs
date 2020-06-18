﻿using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Helper;
using TestingGiant.App.Messages;
using TestingGiant.Data.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.Authentication
{
    public class LoginViewModel : Screen, IDataErrorInfo
    {
        private string username;
        private string password;
        private string message;
        private bool isUsernameOk;
        private bool isPasswordOk;
        private bool enableLoginButton;

        private readonly IEventAggregator eventAggregator;
        private IDeletableEntityRepository<User> userRepository;

        public LoginViewModel(
            IEventAggregator eventAggregator,
            IDeletableEntityRepository<User> userRepository)
        {
            this.eventAggregator = eventAggregator;
            this.userRepository = userRepository;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public bool EnableLoginButton
        {
            get
            {
                return enableLoginButton;
            }
            set
            {
                enableLoginButton = value;
                NotifyOfPropertyChange(() => EnableLoginButton);
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Username")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Username) || Username?.Length <= 5)
                    {
                        isUsernameOk = false;

                        return "Username is Required";
                    }
                    else
                    {
                        isUsernameOk = true;
                    }
                }

                if (columnName == "Password")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Password) || Password?.Length <= 6)
                    {
                        isPasswordOk = false;

                        return "Password is Required";
                    }
                    else
                    {
                        isPasswordOk = true;
                    }
                }

                // If there's no error, null gets returned
                if (isUsernameOk && isPasswordOk)
                    EnableLoginButton = true;

                return null;
            }
        }

        public void AttemptLogin()
        {
            var user = userRepository.All().Where(x => x.Username == this.Username).FirstOrDefault();

            if (user == null)
            {
                this.Message = "Invalid username";
            }
            else
            {
                if (user.Password == HashingHelper.Hash(this.Password))
                {
                    this.eventAggregator.PublishOnUIThread(new SuccessfullyAuthenticatedMessage(user));
                }
                else
                {
                    this.Message = "Invalid password";
                }
            }
        }

        public void Register()
        {
            this.eventAggregator.PublishOnUIThread(new UserToRegistrationMessage());
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}