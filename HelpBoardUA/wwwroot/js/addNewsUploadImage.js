var image_input = document.querySelector("#upload-file");
let uploaded_image = "";

image_input.addEventListener("change", () => {
    const reader = new FileReader();
    reader.addEventListener("load", () => {
        uploaded_image = reader.result;
        document.querySelector("#newsImgBlock").style.backgroundImage = `url(${uploaded_image})`;
    });
    reader.readAsDataURL(image_input.files[0]);
});


var image_input2 = document.querySelector("#upload-file2");
let uploaded_image2 = "";

image_input2.addEventListener("change", () => {
    const reader2 = new FileReader();
    reader2.addEventListener("load", () => {
        uploaded_image2 = reader2.result;
        document.querySelector("#bannerBlock").style.backgroundImage = `url(${uploaded_image2})`;
    });
    reader2.readAsDataURL(image_input2.files[0]);
});




