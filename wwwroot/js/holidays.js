window.displayWeather = false;

function renderCities(cities) {
    $('content').empty()

    $(cities).each(function(i, holiday) {
        elHoliday = $('<div class = "holiday">')
        elHoliday.append($('<h2>' + holiday.name + '</h2>' ));
        elHoliday.append($('<h3>' + holiday.time + '</h3>')); 

        if (holiday.weather.length > 0) {
            elHoliday.append($('<img src = "/images/' + holiday.weather + '.svg" />'));
        }

        if (holiday.population != "") { 
            elHoliday.append($('<p>Population: ' + holiday.population + '</p>'));
        }

        $('content').append(elHoliday);
    });
} 

function requestCities() {
	/**
	for (cookie in Cookies.get()) {
		Cookies.remove(cookie['name'])
	}
	*/

    $.getJSON({
        dataType: "json", 
        url: "/Home/GetCities",
        success: renderCities
    });
}

function startHolidayLoadingLoop() {
    window.holidayLoader = setInterval(requestCities, 1000);
}
