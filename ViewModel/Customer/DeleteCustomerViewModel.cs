﻿using PrototypeEDUCOM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrototypeEDUCOM.ViewModel.Customer
{
    class DeleteCustomerViewModel : BaseViewModel
    {

        public contact contact { get; set; }
        public ICommand cmdArchive { get; set; }
        public ICommand cmdDelete { get; set; }
        public int nbrStudent { get; set; }
        public int nbrRequest { get; set; }

        public Action CloseActionDelete { get; set; }

        public DeleteCustomerViewModel(contact contact)
        {
            this.cmdDelete = new RelayCommand<Object>(actDeleteCustomer);
            this.contact = contact;
            this.nbrRequest = contact.requests.Count();
            this.nbrStudent = contact.students.Count();

        }

        public void actDeleteCustomer(Object o) {
            for (int i = 0; i < nbrRequest; i++ )
            {
                db.requests.Remove(contact.requests.First());
            }

            for (int i = 0; i < nbrStudent; i++ )
            {
                db.students.Remove(contact.students.First());
            }

            db.contacts.Remove(contact);
            db.SaveChanges();
            this.CloseActionDelete();
        }
    }
}
