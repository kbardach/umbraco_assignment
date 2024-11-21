
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

