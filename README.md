# Sky-Bill-Interview

This is the responsive webpage branded using styles from Sky's live website. The project is for the sky interview test, the spec for which can be found at https://github.com/ldabiralai/bill-unattended-test

Prerequisites:
* Visual Studio 2015
* Specflow
* ASP.NET 5 RC1

Instructions:
* Clone/download the solution
* Open the solution in visual studio
* Run the web project using one of the two configured profiles (either IIS Express or web). I would recommend running using web which will cause the site to be hosted by Kestrel (swapping can be achieved using the dropdown as shown in the example image). After starting it hosting with Kestrel you can debug -> Detatch all to leave debug mode. The host process will still be running

<img src="http://blogs.msdn.com/resized-image.ashx/__size/550x0/__key/communityserver-blogs-components-weblogfiles/00-00-00-63-56/0458.commands.png" />

* Only once the site is running can the BDD Tests be run. The Url for the site can be modified via the App.Config
* Both the BDD tests and the Unit Tests can be run through the test explorer in Visual studio

Tests:
* You may notice when running the tests that there is a test that fails. This is because the totals from the source JSON file do not add up. Whilst this could on purpose because of an account balance, I have marked it as a failing test based on the information I currently have.

Notes: 
* To maintain the look and feel of the Sky site, a lot of styling was pulled from the live css. The css was cut down to the salient information for my modified markup and put into the scss files. Some resources e.g. logos are still referencing the live site.
* Since the level of javascript needed was quite low, pure javascript was used instead of a library. This does mean that older browsers will not work. It should also be noted no browser testing was done beyond Chrome and the BDD is only set to test on chrome at the moment.
* All layout e.g header, footer, bill picker and search are purely for display purposes
* The default gulp task, which compiles and minifies the sass and javascript files is set to run at startup and then set to watch the files for changes. If for whatever reason these tasks do not run, they can be triggered manually from the task runner explorer. If you have preinstalled 64 bit node and are having conflicts with visual studios installation please see http://blogs.msdn.com/b/webdev/archive/2015/03/19/customize-external-web-tools-in-visual-studio-2015.aspx
* For the purposes of this demo, some of the markup and styling, e.g. that refering to accessibility settings, were omitted from the project
* For time purposes logging has been achieved with a simple file writter. In a production application this should obviously be substituted for a more robust and thread safe logger
