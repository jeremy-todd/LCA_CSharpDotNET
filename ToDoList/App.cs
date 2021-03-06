﻿using System.Collections.Generic;

namespace ToDoList
{
    class App
    {
        //This class takes the user interactions and passes it to the ItemRepository class

        //Fields
        //No fields are needed for this class.

        //Controller(s)
        public App()
        {

        }

        //instaniate an ItemRepository class
        //ItemRepository repository = new ItemRepository();

        //methods
        public static List<ToDoItem> ReviewToDoList(string filterType, string filterCriteria)
        {
            return ItemRepository.ReviewToDoList(filterType, filterCriteria);
        }
        public static void UpdateItemApp(string todoID, string desc, string dueDate, string status, string priority)
        {
            ItemRepository.UpdateItem(todoID, desc, dueDate, status, priority);
        }
        public static void AddItemApp(string desc, string dueDate, string status, string priority)
        {
            ItemRepository.AddItem(desc, dueDate, status, priority);
        }
        public static void DeleteItemApp(string todoID)
        {
            ItemRepository.DeleteItem(todoID);
        }
        public static bool ToDoIDVerifyApp(string todoID)
        {
            return ItemRepository.ToDoIDVerify(todoID);
        }
    }
}
