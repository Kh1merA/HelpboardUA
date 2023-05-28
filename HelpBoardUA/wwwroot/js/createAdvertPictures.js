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