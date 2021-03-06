﻿using PrototypeEDUCOM.Helper;
using PrototypeEDUCOM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrototypeEDUCOM.ViewModel.Organisation
{
    class AddCampusViewModel : BaseViewModel 
    {
        public program program { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public Validation validName { get; set; }
        public ICommand cmdAdd { get; set; }
        public Action CloseActionAdd { get; set; }
      
        public AddCampusViewModel(program  program) {
            this.program = program;
            this.cmdAdd = new RelayCommand<Object>(actAdd);
        }
        public void actAdd(Object o) {

            bool error = false;
            this.validName = new Validation();

            

            // Validation prénom
            if (!this.name.Equals(""))
            {
                
                this.validName.message = "Valide";
                this.validName.valid = true;
                NotifyPropertyChanged("validName");
            }
            else
            {
                this.validName.message = "Champ requis";
                this.validName.valid = false;
                NotifyPropertyChanged("validName");
                error = true;
            }

            if (!error)
            {
                campu campus = new campu();

                campus.name = this.name;
                campus.street = this.street;
                campus.zip = this.zip;
                campus.city = this.city;
                campus.country = this.country;

                // Enregistre dans la base
                program.campus.Add(campus);

                db.SaveChanges();
                mediator.NotifyViewModel(Helper.Event.ADD_CAMPUS, campus);

                this.CloseActionAdd();
            }
        }
    }
}
