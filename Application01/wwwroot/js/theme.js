window.themeHelper = {
    setTheme: function (theme) {
        localStorage.setItem('theme', theme);
        if (theme === 'dark') {
            document.body.classList.add('dark-theme');
            document.body.classList.remove('light-theme');
        } else {
            document.body.classList.add('light-theme');
            document.body.classList.remove('dark-theme');
        }
    },
    getTheme: function () {
        return localStorage.getItem('theme') || 'light';
    }
};
