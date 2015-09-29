#Moosh v1.0#
#### A C# framework for productivity, speed and fluency.####

[Overview](http://blog.thosakwe.com/2015/moosh/)

#Install#
[Nuget](https://www.nuget.org/packages/Moosh/1.0.0)

To install Moosh, run the following command in the Nuget Package Manager Console:

> PM> Install-Package Moosh

#Why?#
Whilst writing programs, we tend to find ourselves rewriting code to do
the same tasks, over and over. This code is cumbersome to write, and wastes
value time and space. Moosh is a small framework containing classes and
functions designed to get your projects completed in the shortest possible
time.

#Moosh.Moosh#
The Moosh API is easy to use. All functionality can be accessed through
the static Moosh.Moosh class. For convenience, you can use an alias:

```csharp
using M = Moosh.Moosh;
```

Some Moosh functions are contained in classes, like Moosh.Logger, but most
are static functions, like Moosh.Get, or Moosh.Prompt.

```csharp
using System;
using M = Moosh.Moosh;

namespace MooshHttpGet
{
    class Program
    {
        static void Main()
        {
            var url = M.Prompt("Enter a URL to navigate to");
            M.Get(url, (exc, sr) =>
            {
                Console.WriteLine(exc?.ToString() ?? sr.ReadToEnd());
            });
        }
    }
}
```

Moosh was, in fact, to some extent inspired by jQuery, so many functions
work in similar ways. Moosh.Get is able to be used like $.get.

#Features#
Moosh is new at this point, so it can still grow. But for now, here's what
it can do:

* Multithreading
* CSV parsing and serialization
* HTTP
* Extremely easy logging API
* Console helpers
* Settings parsing and serialization to CSV files

#Support#
Thanks for taking a look at Moosh. If you're interested, submit a pull request.

Docs are [here](http://universalfuture.github.io/moosh/).