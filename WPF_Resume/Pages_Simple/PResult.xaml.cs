﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Resume.Pages_Simple
{
    /// <summary>
    /// Interaction logic for PResult.xaml
    /// </summary>
    public partial class PResult : Page
    {
        AplicationContext db = new AplicationContext();

        UserResume userResume;

        public event Action NextPageClicked;
        public PResult()
        {
            InitializeComponent();

            userResume = new UserResume();

            //textBlolckSurname.Text = userResume.Surname.ToString();
            //textBlockName.Text = userResume.UserName.ToString();
            //textBlockPobatkovi.Text = userResume.Pobatkovi.ToString();
            //textBlockDate.Text = userResume.Date.ToString();
            //textBlockAdress.Text = userResume.Adress.ToString();
            //textBlockEmail.Text = userResume.Email.ToString();
            //textBlockEducation.Text = userResume.Education.ToString();
        }
    }
}