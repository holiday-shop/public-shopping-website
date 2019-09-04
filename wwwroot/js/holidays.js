window.displayWeather = false;

function renderHolidays(holidays) {
    $('content').empty()

    $(holidays).each(function(i, holiday) {
        elHoliday = $('<div class = "holiday">')
        elHoliday.append($('<h2>' + holiday.name + '</h2>' ));
        elHoliday.append($('<h3>&euro;' + holiday.cost + '</h3>')); 
		elHoliday.append($('<p>' + holiday.time + '</p>'));

        if (holiday.weather.length > 0) {
            elHoliday.append($('<img src = "/images/' + holiday.weather + '.svg" />'));
        }

        if (holiday.familyFriendly != "") { 
            elHoliday.append($('<p>Family Friendly: ' + holiday.familyFriendly + '</p>'));
        }

        $('content').append(elHoliday);
    });
} 

function requestHolidays() {
	/**
	for (cookie in Cookies.get()) {
		Cookies.remove(cookie['name'])
	}
	*/

    $.getJSON({
        dataType: "json", 
        url: "/Home/GetHolidays",
        success: renderHolidays
    });
}

function startHolidayLoadingLoop() {
    window.holidayLoader = setInterval(requestHolidays, 1000);
}
