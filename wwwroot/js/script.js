function setLanguage(language) {
    localStorage.setItem('selectedLanguage', language);
}

// Function to highlight the selected language
function highlightSelectedLanguage() {
    const currentLanguage = window.location.pathname;  // Check URL path
    const svLink = document.getElementById('sv-link');
    const enLink = document.getElementById('en-link');

    // Remove 'active' and 'active-language' class from both links initially
    svLink.classList.remove('active', 'active-language');
    enLink.classList.remove('active', 'active-language');

    // Check if the URL path includes language, else set default to 'sv'
    if (currentLanguage.includes('/en')) {
        enLink.classList.add('active', 'active-language');
        setLanguage('en');
    } else if (currentLanguage.includes('/sv')) {
        svLink.classList.add('active', 'active-language');
        setLanguage('sv');
    } else {
        // If no language is in the URL, fallback to 'sv'
        svLink.classList.add('active', 'active-language');
        setLanguage('sv');
    }
}

//document.addEventListener('DOMContentLoaded', function () {
//    const form = document.getElementById('search-form');
//    const currentCulture = window.location.pathname.split('/')[1]; // Assumes the culture is the first part of the path

//    // Update the form action based on current culture
//    form.action = `/${currentCulture}/search`;
//});

// Event listeners to set language when links are clicked
document.getElementById('sv-link').addEventListener('click', function () {
    setLanguage('sv');
});

document.getElementById('en-link').addEventListener('click', function () {
    setLanguage('en');
});

// Run highlight function on page load
window.onload = function () {
    highlightSelectedLanguage();  // Highlight language on page load
}

//-----------------------------------------------------------------------------------------------------------------------
//------------------------------------------------Bildspel för restauranger--------------------------------------------------------




//---------------------------------------------------------------------------------------------------------------------------------