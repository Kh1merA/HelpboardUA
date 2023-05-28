window.onload = () => {
    const uploadFile = document.getElementById("upload-file");
    const uploadBtn = document.getElementById("upload-btn");
    const uploadText = document.getElementById("upload-text");

    uploadBtn.addEventListener("click", function () {
        uploadFile.click();
    });

    uploadFile.addEventListener("change", function () {
        if (uploadFile.value) {
            uploadText.innerText = uploadFile.value.match(/[\/\\]([\w\d\s\.\-(\)]+)$/)[1];
        }
        else {
            uploadText.innerText = "Файл не обрано";
        }
    });

    const uploadFile2 = document.getElementById("upload-file2");
    const uploadBtn2 = document.getElementById("addBtn");
    const uploadText2 = document.getElementById("upload-text2");

    uploadBtn2.addEventListener("click", function () {
        uploadFile2.click();
    });

    uploadFile2.addEventListener("change", function () {
        if (uploadFile2.value) {
            uploadText2.innerText = uploadFile2.value.match(/[\/\\]([\w\d\s\.\-(\)]+)$/)[1];
        }
        else {
            uploadText2.innerText = "Файл не обрано";
        }
    });
}