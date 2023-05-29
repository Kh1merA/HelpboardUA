var image_input = document.querySelector('#upload-file');
var newsIcon = document.querySelector('#news-icon');

image_input.addEventListener("change", () => {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
        newsIcon.src = reader.result;
    });

    reader.readAsDataURL(image_input.files[0]);
});

var showTextBtn = document.querySelector('.crtAddBtn');
var textContainer = document.querySelector('#text-container');

showTextBtn.addEventListener('click', function () {
    textContainer.style.display = 'block';
});


