﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace TodoParse
{
	public class TodoItemManager
	{
		IParseStorage storage;

		public TodoItemManager (IParseStorage parseStorage)
		{
			storage = parseStorage;
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return storage.RefreshDataAsync ();
		}

		public Task SaveTaskAsync (TodoItem item)
		{
			return storage.SaveTodoItemAsync (item);
		}

		public Task DeleteTaskAsync (TodoItem item)
		{
			return storage.DeleteTodoItemAsync (item);
		}
	}
}

