using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Helper;
using TestingGiant.App.Messages;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.Authentication
{
    public class RegisterViewModel : Screen, IDataErrorInfo
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string username;
        private string password;
        private string passwordConfirm;
        private string message;

        private bool isFirstNameOk;
        private bool isLastNameOk;
        private bool isEmailOk;
        private bool isPhoneNumberOk;
        private bool isUsernameOk;
        private bool isPasswordOk;
        private bool isPasswordConfirmOk;
        private bool enableRegisterButton;

        private readonly IEventAggregator eventAggregator;
        private IDeletableEntityRepository<User> userRepository;

        public RegisterViewModel(
            IEventAggregator eventAggregator,
            IDeletableEntityRepository<User> userRepository)
        {
            this.eventAggregator = eventAggregator;
            this.userRepository = userRepository;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
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

        public string PasswordConfirm
        {
            get
            {
                return passwordConfirm;
            }
            set
            {
                passwordConfirm = value;
                NotifyOfPropertyChange(() => PasswordConfirm);
            }
        }

        public bool EnableRegisterButton
        {
            get
            {
                return enableRegisterButton;
            }
            set
            {
                enableRegisterButton = value;
                NotifyOfPropertyChange(() => EnableRegisterButton);
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
                if (columnName == "FirstName")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(FirstName) || FirstName?.Length <= 2)
                    {
                        isFirstNameOk = false;

                        return "FirstName is Required";
                    }
                    else
                    {
                        isFirstNameOk = true;
                    }
                }

                if (columnName == "LastName")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(LastName) || LastName?.Length <= 2)
                    {
                        isLastNameOk = false;

                        return "LastName is Required";
                    }
                    else
                    {
                        isLastNameOk = true;
                    }
                }

                if (columnName == "Email")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Email) || Email?.Length <= 8)
                    {
                        isEmailOk = false;

                        return "Email is Required";
                    }
                    else
                    {
                        isEmailOk = true;
                    }
                }

                if (columnName == "PhoneNumber")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(PhoneNumber) || PhoneNumber?.Length <= 2)
                    {
                        isPhoneNumberOk = false;

                        return "PhoneNumber is Required";
                    }
                    else
                    {
                        isPhoneNumberOk = true;
                    }
                }

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

                if (columnName == "PasswordConfirm")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(PasswordConfirm) || PasswordConfirm?.Length <= 6)
                    {
                        isPasswordConfirmOk = false;

                        return "PasswordConfirm is Required";
                    }
                    else
                    {
                        isPasswordConfirmOk = true;
                    }
                }

                // If there's no error, null gets returned
                if (isFirstNameOk && isLastNameOk && isEmailOk && isPhoneNumberOk && isUsernameOk && isPasswordOk && isPasswordConfirmOk)
                    EnableRegisterButton = true;

                return null;
            }
        }

        public void AttemptRegistration()
        {
            if (this.Password != this.PasswordConfirm)
            {
                this.Message = "Password do not match!";
            }
            else
            {
                var user = userRepository.All().Where(x => x.Username == this.Username || x.Email == this.Email).FirstOrDefault();

                if (user == null)
                {
                    var userEntity = new User
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        Email = this.Email,
                        PhoneNumber = this.PhoneNumber,
                        Username = this.Username,
                        Password = HashingHelper.Hash(this.Password),
                        Role = UserRole.Public
                    };

                    try
                    {
                        this.userRepository.Add(userEntity);
                        this.userRepository.SaveChanges();

                        this.eventAggregator.PublishOnUIThread(new UserToLoginMessage("You have registered successfully."));
                    }
                    catch(Exception ex)
                    {
                        this.Message = "Ooops! Something went wrong...";
                    }
                }
                else if (user.Email == this.Email && user.Username == this.Username)
                {
                    this.Message = "Username and Email are already taken!";
                }
                else if (user.Email == this.Email)
                {
                    this.Message = "Email is already taken!";
                }
                else
                {
                    this.Message = "Username is already taken!";
                }
            }
        }

        public void BackToLogin()
        {
            this.eventAggregator.PublishOnUIThread(new UserToLoginMessage());
        }

        protected override void OnActivate()
        {
            this.ResetProperties();
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            this.ResetProperties();
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }

        private void ResetProperties()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            PasswordConfirm = string.Empty;

            isFirstNameOk = false;
            isLastNameOk = false;
            isEmailOk = false;
            isPhoneNumberOk = false;
            isUsernameOk = false;
            isPasswordOk = false;
            isPasswordConfirmOk = false;

            EnableRegisterButton = false;
        }
    }
}