// Navbar'daki "Rezervasyon Yap" butonuna tıklanınca giriş kontrolü
document.addEventListener("DOMContentLoaded", function () {
    const rezervasyonBtn = document.querySelector("a[href='/Reservation/Check']");

    if (rezervasyonBtn) {
        rezervasyonBtn.addEventListener("click", function (event) {
            const isAuthenticated = document.body.dataset.authenticated === "true";

            if (!isAuthenticated) {
                event.preventDefault();
                window.location.href = "/Auth/Login";
            }
        });
    }
});
