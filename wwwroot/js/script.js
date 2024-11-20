
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

//-----------------------------------------------------------------------------------------------------------------------
//------------------------------------------------Back to Top--------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------