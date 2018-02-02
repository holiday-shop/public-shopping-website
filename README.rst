dotnetcore-city-info
====================

A simple demo application that refreshes information about cities and shows the
results on a web page. This demonstrates severeal features of OpenShift
Container Platform.

.. image:: var/screenshot.png

Deploying a feature branch in a A/B deployment.
----

* Use the .NET Core Builder Image to deploy (the master branch) as normal. This
must be built with a v2.0 builder.

.. image:: var/dotnetBuilder.png

* Add to the project again, with a .NET Core Builder Image. This time, use an
**advanced options** to and specify the **feature_weather** branch.

.. image:: var/advOptions.png

.. image:: var/gitReference.png

* Dot *not* deploy a new route.

.. image:: var/noRoute.png

* You should have something that looks like this;

.. image:: var/overview.png

* Now go find the route, and edit it. You want to "Split traffic across
multiple services" and select the new feature branch.

.. image:: var/splitRoute.png

Once saved, it should look something like this;

.. image:: var/splitRouteOverview.png

* Now go view the application. 

Press Ctrl + F5 to refresh the page. Half of the time, you'll get weather
icons, half of the time, you'll not get weather icons. Make sure Cookies are
disabled to disable session persistance. 

.. image:: var/withWeather.png

.. image:: var/withoutWeather.png
