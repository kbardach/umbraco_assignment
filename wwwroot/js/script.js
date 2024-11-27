
function setLanguage(language) {
    localStorage.setItem('selectedLanguage', language);
}

document.querySelectorAll('.language-item a').forEach(link => {
    link.addEventListener('click', function () {
        const languageCode = this.textContent.trim().toLowerCase(); 
        setLanguage(languageCode); 
    });
});

document.addEventListener('DOMContentLoaded', function () {
    console.log('DOMContentLoaded event fired'); // Check if this runs

    const searchInput = document.getElementById('searchQuery');
    const searchButton = document.querySelector('.search-button');

    if (searchInput && searchButton) {
        console.log('Elements found, initializing script'); // Debugging

        function toggleButtonState() {
            searchButton.disabled = searchInput.value.trim() === '';
        }

        // Set the initial state
        toggleButtonState();

        // Add event listener to input field
        searchInput.addEventListener('input', toggleButtonState);
    } else {
        console.error('Search input or button not found!');
    }
});

document.addEventListener("DOMContentLoaded", () => {
    const backToTopButton = document.getElementById("back-to-top");

    if (backToTopButton) {
        backToTopButton.addEventListener("click", () => {
            window.scrollTo({
                top: 0,
                behavior: "smooth" // Smidig scrollning till toppen
            });
        });
    }
});

//-----------------------------------------------------------------------------------------------------------------------
//------------------------------------------------Back to Top--------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------
//------------------------------------------------ Change language in form --------------------------------------------------------

document.addEventListener("DOMContentLoaded", function () {
    // Hämta språket från <html lang=""> taggen
    const language = document.documentElement.lang || "en"; // Standard till engelska om lang saknas

    document.querySelectorAll("[required]").forEach(function (input) {
        input.oninvalid = function (e) {
            if (language === "en") {
                e.target.setCustomValidity("Please fill out this field.");
            } else if (language === "sv") {
                e.target.setCustomValidity("Fyll i det här fältet.");
            } else {
                e.target.setCustomValidity(""); // Fallback för andra språk
            }
        };
        input.oninput = function (e) {
            e.target.setCustomValidity(""); // Återställ vid ny inmatning
        };
    });
});
//---------------------------------------------------------------------------------------------------------------------------------
//------------------------------------------------ Script för karta --------------------------------------------------------

document.addEventListener("DOMContentLoaded", function () {
    const mapElement = document.getElementById("map");
    const longitude = parseFloat(mapElement.getAttribute("data-longitude"));
    const latitude = parseFloat(mapElement.getAttribute("data-latitude"));

    const map = new ol.Map({
        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([longitude, latitude]),
            zoom: 17
        })
    });

    const iconFeature = new ol.Feature({
        geometry: new ol.geom.Point(ol.proj.fromLonLat([longitude, latitude]))
    });

    const vectorSource = new ol.source.Vector({
        features: [iconFeature]
    });

    const iconStyle = new ol.style.Style({
        image: new ol.style.Icon({
            src: 'data:image/svg+xml;charset=utf-8,' + encodeURIComponent('<svg xmlns="http://www.w3.org/2000/svg" width="54" height="54" fill="red" viewBox="0 0 24 24"><path d="M12 2C8.686 2 6 4.686 6 8c0 5.25 6 12 6 12s6-6.75 6-12c0-3.314-2.686-6-6-6zm0 9c-1.657 0-3-1.343-3-3s1.343-3 3-3 3 1.343 3 3-1.343 3-3 3z"/></svg>')
        })
    });

    iconFeature.setStyle(iconStyle);

    const vectorLayer = new ol.layer.Vector({
        source: vectorSource
    });

    map.addLayer(vectorLayer);
});
//---------------------------------------------------------------------------------------------------------------------------------

