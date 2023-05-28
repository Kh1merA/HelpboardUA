window.onload = () => {
    const uploadFile = document.getElementById("upload-file");
    const uploadBtn = document.getElementById("upload-btn");
    const uploadText = document.getElementById("upload-text");

    uploadBtn.addEventListener("click", function () {
        uploadFile.click();
    });

    uploadFile.addEventListener("change", function () {
        const fileName = uploadFile.value;
        const validExtensions = ["jpg", "jpeg", "png", "svg"];
        const fileExtension = fileName.split(".").pop().toLowerCase();

        if (!fileName) {

            uploadText.innerText = "Файл не обрано";
        } else if (validExtensions.includes(fileExtension)) {
            uploadText.innerText = fileName.match(/[\/\\]([\w\d\s\.\-(\)]+)$/)[1];
        } else {
            uploadFile.value = null;
            uploadText.innerText = "Файл має непідтримуваний формат";
        }
    });

    const uploadFile2 = document.getElementById("upload-file2");
    const uploadBtn2 = document.getElementById("addBtn");
    const uploadText2 = document.getElementById("upload-text2");

    uploadBtn2.addEventListener("click", function () {
        uploadFile2.click();
    });

    uploadFile2.addEventListener("change", function () {
        const fileName2 = uploadFile2.value;
        const validExtensions2 = ["jpg", "jpeg", "png", "svg"];
        const fileExtension2 = fileName2.split(".").pop().toLowerCase();

        if (!fileName2) {

            uploadText2.innerText = "Файл не обрано";
        } else if (validExtensions2.includes(fileExtension2)) {
            uploadText2.innerText = fileName2.match(/[\/\\]([\w\d\s\.\-(\)]+)$/)[1];
        } else {
            uploadFile2.value = null;
            uploadText2.innerText = "Файл має непідтримуваний формат";
        }
    });
}


