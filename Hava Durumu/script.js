const wrapper = document.querySelector(".wrapper"),
inputPart = wrapper.querySelector(".input-part"),
infoTxt = inputPart.querySelector(".info-txt"),
inputField = inputPart.querySelector("input"),
locationBtn = inputPart.querySelector("button")
wIcon = document.querySelector(".weather-part img")
arrowBack = document.querySelector("header i")
let api;

inputField.addEventListener("keyup", e => {
    if(e.key == "Enter" && inputField.value != ""){
        requestApi(inputField.value)
    }
})

locationBtn.addEventListener("click", ()=>{
    if(navigator.geolocation){
        navigator.geolocation.getCurrentPosition(onSuccess, onError)
    }else{
        console.log("Tarayıcınız geolocation'ı desteklemiyor...")
    }
})

function onSuccess(position){
    const {latitude, longitude} = position.coords;
    api = `https://api.openweathermap.org/data/2.5/weather?lat=${latitude}&lon=${longitude}&units=metric&appid=a16e33bdb752c9b5778d38c42614a6e4&lang=tr`;
    console.log(api)
    fetchData()
}

function onError(error){
    infoTxt.innerText = error.message   
    infoTxt.classList.add("error")
}

function requestApi(city){
    api = `https://api.openweathermap.org/data/2.5/weather?q=${city}&units=metric&appid=a16e33bdb752c9b5778d38c42614a6e4&lang=tr`;
    fetchData()
}

function fetchData(){
    infoTxt.innerText = "Sonuçlar getiriliyor..."
    infoTxt.classList.add("pending")
    fetch(api).then(response => response.json()).then(result => weatherDetails(result))
}


function weatherDetails(info){
    if(info.cod == "404"){
        infoTxt.classList.replace("pending", "error")
        infoTxt.innerText = `${inputField.value} Şehir bulunamadı...`
    }else{
        const city = info.name
        const country = info.sys.country
        const {description, id} = info.weather[0]
        const {feels_like, humidity, temp, pressure} = info.main
        const {speed} = info.wind

        if(id==800){
            wIcon.src = "Img/clear.svg"
        }else if(id => 200 && id <= 232){
            wIcon.src = "Img/storm.svg"
        }else if(id => 600 && id <= 622){
            wIcon.src = "Img/snow.svg"
        }else if(id => 701 && id <= 781){
            wIcon.src = "Img/haze.svg"
        }else if(id => 801 && id <= 804){
            wIcon.src = "Img/cloud.svg"
        }else if(id => 300 && id <= 321 || (id => 500 && id <= 531)){
            wIcon.src = "Img/rain.svg"
        }
        

        wrapper.querySelector(".temp .numb").innerText = Math.floor(temp)
        wrapper.querySelector(".weather").innerText = description
        wrapper.querySelector(".location").innerText = `${city}, ${country}`
        wrapper.querySelector(".temp .numb-2").innerText = Math.floor(feels_like)
        wrapper.querySelector(".humidity span").innerText = `${humidity}%`
        wrapper.querySelector(".wind .speed").innerText = `${speed} km/s`
        wrapper.querySelector(".wind .pressure").innerText = `${pressure} mb`


        infoTxt.classList.remove("pending", "error")
        wrapper.classList.add("active")

    }
    
}

arrowBack.addEventListener("click", () => {
    wrapper.classList.remove("active")
})