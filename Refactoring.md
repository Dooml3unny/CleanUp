## Мёртвый код

### Причины
Некоторые переменные в методе MainWindowViewModel больше не используются.

### Лечение

Удаляем неиспользуемые переменные.

      public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            _ListViewModel = new CollectionViewModel();
            //CurrentViewModel = new ListDocumentsViewModel();
            //CustomerListViewModel custListViewModel = new CustomerListViewModel();
           //OrderViewModel orderViewModelModel = new OrderViewModel();  
        }
        
После изменения:

       public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            _ListViewModel = new CollectionViewModel();            
        }    
         
    
### Выйгрыш
Уменьшает размер кода и упрощает его поддержку.

## Извлечение метода

### Причины
В методах GetNewName и DeleteCollection имеется фрагмент кода который можно сгруппировать.

### Лечение 
Выделяем участок кода в новый метод.
    
     private void GetNewName(object destination)
        {
            addDocumenView = new AddDocumentView();

            if (addDocumenView.ShowDialog() == true)
            {
                var tempName = (addDocumenView.DataContext as AddDocumentViewModel).NewName;
                var tempPath = (addDocumenView.DataContext as AddDocumentViewModel).PathDocument;
                using (UserContext db = new UserContext())
                {
                    Document doc = new Document
                    {
                        Name = tempName,
                        DateСreation = DateTime.Now,
                        FilePath = tempPath,
                        DateLastChange = DateTime.Now,
                        Collection = db.Collections.Where(x => x.Id == (collection).Id).ToList().FirstOrDefault(),
                        CollectionId = this.collection.Id
                    };
                    db.Documents.Add(doc);

                    if (db.SaveChanges() == 1)
                    {
                        UpDateListDocuments(db);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка базы данных!");
                    }
                }                
            }
            
     private void DeleteCollection(object destination)
        {
            if (document != null)
            {
                confirmMessageView = new ConfirmMessageView("Вы уверены, что хотите удалить эту коллекцию?");

                if (confirmMessageView.ShowDialog() == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var temp = db.Documents.Find(document.Id);

                        db.Documents.Remove(temp);

                        if (db.SaveChanges() == 1)
                        {
                            UpDateListDocuments(db);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка базы данных!");
                        }
                    }
                }
            }
    
После изменения:

    private void SaveChanges()
        {
          if (db.SaveChanges() == 1)
          {
               UpDateListDocuments(db);
          }
          else
          {
               MessageBox.Show("Ошибка базы данных!");
          }            
        }
    
### Выйгрыш
Улучшает читабильность кода. Изолирует независимые части кода, уменьшая вероятность возникновения ошибок. 

## Дублирование кода

### Причины
Один и тот же участок кода присутствует в двух методах одного и того же класса: в GetNewName и в DeleteCollection.

### Лечение 
Применяем **извлечение метода** (см. выше) и вызываем код созданного метода из обоих участков.
    
      private void GetNewName(object destination)
        {
            addDocumenView = new AddDocumentView();

            if (addDocumenView.ShowDialog() == true)
            {
                var tempName = (addDocumenView.DataContext as AddDocumentViewModel).NewName;
                var tempPath = (addDocumenView.DataContext as AddDocumentViewModel).PathDocument;
                using (UserContext db = new UserContext())
                {
                    Document doc = new Document
                    {
                        Name = tempName,
                        DateСreation = DateTime.Now,
                        FilePath = tempPath,
                        DateLastChange = DateTime.Now,
                        Collection = db.Collections.Where(x => x.Id == (collection).Id).ToList().FirstOrDefault(),
                        CollectionId = this.collection.Id
                    };
                    db.Documents.Add(doc);

                    if (db.SaveChanges() == 1)
                    {
                        UpDateListDocuments(db);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка базы данных!");
                    }
                }                
            }
            
     private void DeleteCollection(object destination)
        {
            if (document != null)
            {
                confirmMessageView = new ConfirmMessageView("Вы уверены, что хотите удалить эту коллекцию?");

                if (confirmMessageView.ShowDialog() == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var temp = db.Documents.Find(document.Id);

                        db.Documents.Remove(temp);

                        if (db.SaveChanges() == 1)
                        {
                            UpDateListDocuments(db);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка базы данных!");
                        }
                    }
                }
            }
    
После изменения:

    private void GetNewName(object destination)
        {
            addDocumenView = new AddDocumentView();

            if (addDocumenView.ShowDialog() == true)
            {
                var tempName = (addDocumenView.DataContext as AddDocumentViewModel).NewName;
                var tempPath = (addDocumenView.DataContext as AddDocumentViewModel).PathDocument;
                using (UserContext db = new UserContext())
                {
                    Document doc = new Document
                    {
                        Name = tempName,
                        DateСreation = DateTime.Now,
                        FilePath = tempPath,
                        DateLastChange = DateTime.Now,
                        Collection = db.Collections.Where(x => x.Id == (collection).Id).ToList().FirstOrDefault(),
                        CollectionId = this.collection.Id
                    };
                    db.Documents.Add(doc);

                    SaveChanges();
                }                
           }
            
     private void DeleteCollection(object destination)
        {
            if (document != null)
            {
                confirmMessageView = new ConfirmMessageView("Вы уверены, что хотите удалить эту коллекцию?");

                if (confirmMessageView.ShowDialog() == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var temp = db.Documents.Find(document.Id);

                        db.Documents.Remove(temp);

                        SaveChanges();
                    }
                }
           }
           
        private void SaveChanges()
        {
          if (db.SaveChanges() == 1)
          {
               UpDateListDocuments(db);
          }
          else
          {
               MessageBox.Show("Ошибка базы данных!");
          }            
        }
    
### Выйгрыш
Улучшает структуру кода. Уменьшает его объём. 
