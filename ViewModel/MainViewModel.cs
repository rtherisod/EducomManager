﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrototypeEDUCOM.ViewModel
{


    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            tabs = new ObservableCollection<Tab>();
            tabs.Add(new Tab("Dashboard", new View.Dashboard.DashboardUCView(), "../Ressource/dashboard.png"));
            tabs.Add(new Tab("Clients", new View.Customer.CustomerUCView(), "../Ressource/clients.png"));
            tabs.Add(new Tab("Organisations", new View.Organisation.OrganisationUCView(), "../Ressource/organisations.png"));
        }
    }
}
