TodoASMX
========

This sample demonstrates a Todo list application where the data is stored and accessed from an ASMX web service. The web service is hosted by Xamarin and provides read-only access to the data. Therefore, the operations that create, update, and delete data will not alter the data consumed in the application. However, a hostable version of the ASMX service that provides read-write access to the data is stored in the *TodoASMXService* folder.

The app functionality is:

- View a list of tasks.
- Add, edit, and delete tasks.
- Set a task's status to 'done'.
- Speak the task's name and notes fields.

In all cases the tasks are stored in an in-memory collection that's accessed through an ASMX web service.

For more information about the sample see [Consuming an ASP.NET Web Service (ASMX)](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/asmx/).

Author
------

David Britch
