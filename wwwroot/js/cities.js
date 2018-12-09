window.displayWeather = false;

function renderCities(cities) {
    $('content').empty()

    $(cities).each(function(i, city) {
        elCity = $('<div class = "city">')
        elCity.append($('<h2>' + city.name + '</h2>' ));
        elCity.append($('<h3>' + city.time + '</h3>')); 

        if (city.weather.length > 0) {
            elCity.append($('<img src = "/images/' + city.weather + '.svg" />'));
        }

        if (city.population != "") { 
            elCity.append($('<p>Population: ' + city.population + '</p>'));
        }

        $('content').append(elCity);
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

function startCityLoadingLoop() {
    window.cityLoader = setInterval(requestCities, 1000);
}
