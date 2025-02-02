const weather_container = $("#weather-list");
const ICON_SRC = "/icons";

$(document).ready(function () {
    $("#weather-search").click(function () {
        $("#weather-alert").empty();
        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        if (!startDate || !endDate) {
            alert("Please fill in both dates before searching!");            
            return;
        }

        $.ajax({
            url: "/Weather/Search", 
            method: "GET",
            data: { startDate: startDate, endDate: endDate },
            success: function (response) {                
                if (!response[0]?.date) {
                    alert("Please check the entered dates and try again!");
                    return;
                } else {
                    weather_container.empty();
                    response.forEach((weather) => {
                        weather_container[0].append(mountWeatherDisplay(weather));
                    });
                }
            },            
        });
    });
});

function mountWeatherDisplay(weather_object) {
    let weather = document.createElement("DIV");
    weather.classList.add("weather-display");

    let header = document.createElement("SPAN");
    header.innerText = `${weather_object.date}`;

    let footer = document.createElement("SPAN");
    footer.innerText = weather_object.summary;

    let temperature = document.createElement("SPAN");
    temperature.classList.add("weather-temperature");
    temperature.innerText = `${weather_object.temperatureC}`;

    let icon = document.createElement("LABEL");
    const icon_img = document.createElement("IMG");
    icon_img.src = `${weather_object.icon}`;
    icon.appendChild(icon_img);

    weather.appendChild(header);
    weather.appendChild(temperature);
    weather.appendChild(icon);
    weather.appendChild(footer);

    return weather;
}

function sendWeatherAlert(message) {
    let weatherAlert = document.createElement("P");
    weatherAlert.innerText = `${message}`;    
    return weather;
}