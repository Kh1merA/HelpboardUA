var image_input = document.querySelector('#upload-file');
var newsIcon = document.querySelector('#news-icon');

image_input.addEventListener("change", () => {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
        newsIcon.src = reader.result;
    });

    reader.readAsDataURL(image_input.files[0]);
});


var image_input2 = document.querySelector('#upload-file2');
var newsIcon2 = document.querySelector('#bannerIcon');

image_input2.addEventListener("change", () => {
    const reader2 = new FileReader();

    reader2.addEventListener("load", () => {
        newsIcon2.src = reader2.result;
    });

    reader2.readAsDataURL(image_input2.files[0]);
});


var showTextBtn = document.querySelector('.editNewsBtn');
var textContainer = document.querySelector('#text-container');

showTextBtn.addEventListener('click', function () {
    textContainer.style.display = 'block';
});