const weather_container = $("#weather-list");
const ICON_SRC = "/icons";

$.ajax({
    url: "/Weather/Calendar",
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
    icon.appendChild(getIcon(weather_object.summary));
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

function getIcon(summary) {
    const icon_img = document.createElement("IMG");
    switch (summary) {
        case "Frio":
            icon_img.src = ICON_SRC + "/snowflake-solid.svg";
            break;
        case "Nublado":
            icon_img.src = ICON_SRC + "/smog-solid.svg";
            break;
        case "Ensolarado":
            icon_img.src = ICON_SRC + "/sun-solid.svg";
            break;
        case "Chuvoso":
            icon_img.src = ICON_SRC + "/rain-solid.svg";
            break;
    }
    return icon_img;
}