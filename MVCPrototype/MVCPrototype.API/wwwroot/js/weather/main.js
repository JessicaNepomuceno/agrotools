const weather_container = $("#weather-list");
const ICON_SRC = "/icons";

$.ajax({
    url: "/Weather",
    type: "GET",
    success: (response) => {
        for (const weather of response) {               
            weather_container[0].appendChild(mountWeatherDisplay(weather));
        }
    }
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

    let dayOfWeek = document.createElement("SPAN");
    dayOfWeek.classList.add("weather-dayOfWeek");
    dayOfWeek.innerText = `${weather_object.dayOfWeek}`;    

    weather.appendChild(header);
    weather.appendChild(dayOfWeek);
    weather.appendChild(temperature);
    weather.appendChild(icon);
    weather.appendChild(footer);

    return weather;
}