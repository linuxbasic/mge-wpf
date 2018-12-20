using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System.Collections.Generic;

namespace me.basig.linus.mge
{
    public class CustomerViewModel : BindableBase
    {
        private LibraryAdminService Service;
        private List<Customer> _allCustomers;
        public List<Customer> AllCustomers {
            get
            {
                return _allCustomers;
            }
            private set
            {
                SetProperty(ref _allCustomers, value, nameof(AllCustomers));
            }
        }
        private Customer _customerInEditor;
        public Customer CustomerInEditor
        {
            get { return _customerInEditor; }
            set
            {
                if (!HasUnsavedChanges)
                {
                    SetProperty(ref _customerInEditor, value, nameof(CustomerInEditor));
                    UpdateEditorFields();
                    OnPropertyChanged(nameof(CanDelete));
                    OnPropertyChanged(nameof(HasUnsavedChanges));
                    OnPropertyChanged(nameof(CanSave));
                }
            }
        }

        public bool CanDelete
        {
            get
            {
                return CustomerInEditor != null && IsExistingCustomer(CustomerInEditor);
            }
        }
        public bool CanSave
        {
            get
            {
                return HasUnsavedChanges
                    && EditorStudentnumber != ""
                    && EditorStudentnumber != null
                    && EditorName != ""
                    && EditorName != null
                    && EditorEmail != ""
                    && EditorEmail != null
                    && EditorPassword != ""
                    && EditorPassword != null;
            }
        }
        public bool HasUnsavedChanges
        {
            get {
                return CustomerInEditor != null && (
                    CustomerInEditor.Studentnumber != EditorStudentnumber ||
                    CustomerInEditor.Name != EditorName || 
                    CustomerInEditor.Email != EditorEmail ||
                    CustomerInEditor.Password != EditorPassword
                    );
            }
        }
        private string _editorStudentnumber;
        public string EditorStudentnumber
        {
            get
            {
                return _editorStudentnumber;
            }
            set
            {
                SetProperty(ref _editorStudentnumber, value, nameof(EditorStudentnumber));
                OnPropertyChanged(nameof(HasUnsavedChanges));
                OnPropertyChanged(nameof(CanSave));
            }
        }
        private string _editorName;
        public string EditorName
        {
            get
            {
                return _editorName;
            }
            set
            {
                SetProperty(ref _editorName, value, nameof(EditorName));
                OnPropertyChanged(nameof(HasUnsavedChanges));
                OnPropertyChanged(nameof(CanSave));
            }
        }
        private string _editorEmail;
        public string EditorEmail
        {
            get
            {
                return _editorEmail;
            }
            set
            {
                SetProperty(ref _editorEmail, value, nameof(EditorEmail));
                OnPropertyChanged(nameof(HasUnsavedChanges));
                OnPropertyChanged(nameof(CanSave));
            }
        }
        private string _editorPassword;
        public string EditorPassword
        {
            get
            {
                return _editorPassword;
            }
            set
            {
                SetProperty(ref _editorPassword, value, nameof(EditorPassword));
                OnPropertyChanged(nameof(HasUnsavedChanges));
                OnPropertyChanged(nameof(CanSave));
            }
        }


        public CustomerViewModel(LibraryAdminService service)
        {
            Service = service;
        }

        public void LoadCustomers()
        {
            AllCustomers = Service.GetAllCustomers();
            NewCustomer();
        }

        public void NewCustomer()
        {
            CustomerInEditor = new Customer();
        }

        public void SaveCustomer()
        {
            CustomerInEditor.Studentnumber = EditorStudentnumber;
            CustomerInEditor.Name = EditorName;
            CustomerInEditor.Password = EditorPassword;
            CustomerInEditor.Email = EditorEmail;
            if (IsExistingCustomer(CustomerInEditor))
            {
                Service.UpdateCustomer(CustomerInEditor);
            }
            else
            {
                Service.AddCustomer(CustomerInEditor);
            }
            LoadCustomers();
            
        }

        public bool IsExistingCustomer(Customer customer)
        {
            return AllCustomers.Contains(customer);
        }

        public void DeleteCustomer()
        {
            Service.DeleteCustomer(CustomerInEditor);
            LoadCustomers();
        }

        public void ResetCustomer()
        {
            UpdateEditorFields();
        }

        private void UpdateEditorFields()
        {
            if(CustomerInEditor != null)
            {
                EditorStudentnumber = CustomerInEditor.Studentnumber;
                EditorName = CustomerInEditor.Name;
                EditorEmail = CustomerInEditor.Email;
                EditorPassword = CustomerInEditor.Password;
            }
        }
    }
}
