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

namespace PrototypeEDUCOM.View.Organisation
{
    /// <summary>
    /// Logique d'interaction pour OrganisationUCView.xaml
    /// </summary>
    public partial class OrganisationUCView : UserControl
    {
        public OrganisationUCView()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Organisation.OrganisationViewModel();
        }
    }
}
