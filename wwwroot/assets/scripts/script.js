window.onload = () => {
  const toggleLinks = document.querySelector(".toggle-button"),
    links = document.querySelector("nav ul.links");

  toggleLinks.onclick = function () {
    links.classList.toggle("toggle");
  };
};
