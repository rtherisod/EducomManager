﻿using PrototypeEDUCOM.Helper;
using PrototypeEDUCOM.Model;
using PrototypeEDUCOM.View.Customer;
using PrototypeEDUCOM.View.Dashboard;
using PrototypeEDUCOM.ViewModel.Customer;
using PrototypeEDUCOM.ViewModel.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrototypeEDUCOM.ViewModel
{

    public class MediatorViewModel
    {

        private Dictionary<string, List<BaseViewModel>> container = new Dictionary<string, List<BaseViewModel>>();

        public Dictionary<string, BaseViewModel> TabViewModel = new Dictionary<string,BaseViewModel>();
        public Dictionary<string, UserControl> TabUC = new Dictionary<string, UserControl>();

        private static MediatorViewModel instance;

        public Helper.Enum.User roleUser { get; set; }

        public static MediatorViewModel getInstance()
        {
            if (instance == null)
                instance = new MediatorViewModel();
            return instance;
        }


        public void Register(string eventName, BaseViewModel vm)
        {
            if (!container.ContainsKey(eventName))
                container[eventName] = new List<BaseViewModel>();

            container[eventName].Add(vm);
        }

        public void NotifyViewModel(string eventName, object item)
        {
            if (container.ContainsKey(eventName))
                foreach (BaseViewModel vm in container[eventName])
                    vm.Update(eventName, item);
        } 

        public void openAddCustomerView()
        {
            AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel();
            AddCustomerView addCustomerView = new AddCustomerView();

            addCustomerView.DataContext = addCustomerViewModel;
            addCustomerViewModel.CloseActionFormAdd = new Action(() => addCustomerView.Close());

            addCustomerView.Show();
        }

        public void openEditCustomerView(contact customer)
        {
            EditCustomerViewModel editCustomerViewModel = new EditCustomerViewModel(customer);
            EditCustomerView editCustomerView = new EditCustomerView();

            editCustomerView.DataContext = editCustomerViewModel;
            editCustomerViewModel.CloseActionFormAdd = new Action(() => editCustomerView.Close());

            editCustomerView.Show();
        }

        public void openDeleteCustomerView(contact customer)
        {
            DeleteCustomerViewModel deleteCustomerViewModel = new DeleteCustomerViewModel(customer);
            DeleteCustomerView deleteCustomerView = new DeleteCustomerView();

            deleteCustomerView.DataContext = deleteCustomerViewModel;
            deleteCustomerViewModel.CloseActionDelete = new Action(() => deleteCustomerView.Close());

            deleteCustomerView.ShowDialog();
        }

        public void openShowCustomerView(contact customer)
        {
            ShowCustomerUCView showCustomerView = new ShowCustomerUCView(customer);
            showCustomerView.DataContext = new ShowCustomerViewModel(customer);

            ((CustomerViewModel)TabViewModel["customer"]).actAddTab(customer, showCustomerView);

        }

        public void createTabViewModel()
        {
            if (this.roleUser != Helper.Enum.User.assistant)
            {

                DashboardViewModel dashboardViewModel = new DashboardViewModel();
                DashboardUCView dashboardUCView =  new DashboardUCView();

                dashboardUCView.DataContext = dashboardViewModel;

                TabViewModel.Add("dashboard", dashboardViewModel);
                TabUC.Add("dashboard",dashboardUCView);

            }

            CustomerViewModel customerViewModel = new CustomerViewModel();
            CustomerUCView customerUCView = new CustomerUCView();

            customerUCView.DataContext = customerViewModel;

            TabViewModel.Add("customer", customerViewModel);
            TabUC.Add("customer", customerUCView);
        }

        public void openAddStudentView(contact customer) {
            AddStudentViewModel addStudentViewModel = new AddStudentViewModel(customer);
            AddStudentView addStudentView = new AddStudentView();

            addStudentView.DataContext = addStudentViewModel;
            addStudentViewModel.CloseActionAdd = new Action(() => addStudentView.Close());

            addStudentView.Show();
        }
        public void openEditStudentView(student student) {
            EditStudentViewModel editStudentViewModel = new EditStudentViewModel(student);
            EditStudentView editStudentView = new EditStudentView();

            editStudentView.DataContext = editStudentViewModel;
            editStudentViewModel.CloseActionEdit = new Action(() => editStudentView.Close());

            editStudentView.Show();
       
        }
        public void openDeleteStudentView(student student) {

            DeleteStudentViewModel deleteStudentViewModel = new DeleteStudentViewModel(student);
            DeleteStudentView deleteStudentView = new DeleteStudentView();

            deleteStudentView.DataContext = deleteStudentViewModel;
            deleteStudentViewModel.CloseActionDelete = new Action(() => deleteStudentView.Close());

            deleteStudentView.ShowDialog();
        }
        
    }
}
