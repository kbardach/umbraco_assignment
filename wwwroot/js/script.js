function setLanguage(language) {
    localStorage.setItem('selectedLanguage', language);
}

document.querySelectorAll('.language-item a').forEach(link => {
    link.addEventListener('click', function () {
        const languageCode = this.textContent.trim().toLowerCase(); 
        setLanguage(languageCode); 
    });
});

//-----------------------------------------------------------------------------------------------------------------------
//------------------------------------------------Bildspel för restauranger--------------------------------------------------------




//---------------------------------------------------------------------------------------------------------------------------------