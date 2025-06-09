//let alert =
//{
//    confirmDelete: function (callback) {
//        Swal.fire({
//            title: "Are you sure?",
//            text: "You won't be able to revert this!",
//            icon: "warning",
//            showCancelButton: true,
//            confirmButtonColor: "#3085d6",
//            cancelButtonColor: "#d33",
//            confirmButtonText: "Yes, delete it!"
//        }).then((result) => {
//            if (result.isConfirmed) {
//                callback(result)

//            }
//        });
//    }
//    ,

//    Success: function (title, text) {

//        Swal.fire({
//            title: title,
//            text: text,
//            icon: "success"
//        });
//    },

//    Error: function (title, text) {

//        Swal.fire({
//            title: title,
//            text: text,
//            icon: "error"
//        });
//    }


//}




// With Cancel Message
let SweetAlertHelper =
{
    confirmDelete: function (callback, titleMsg = "Are you sure?", textMsg = "You won't be able to revert this!") {
        Swal.fire({
            title: titleMsg ,
            text: textMsg,
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#1cbb8c",
            cancelButtonColor: "#ff3d60",
            confirmButtonText: "Yes, delete it!"
        }).then(function (result) {
            if (result.value) {
                callback(result)

            }
        });
    },



    Success: function (title, text) {
        Swal.fire({
            title: title,
            text: text,
            icon: "success"
        });
    },

    Error: function (title, text) {
        Swal.fire({
            title: title,
            text: text,
            icon: "error"
        });
    }



}













//Swal.fire({
//    title: "Are you sure?",
//    text: "You won't be able to revert this!",
//    icon: "warning",
//    showCancelButton: true,
//    confirmButtonColor: "#3085d6",
//    cancelButtonColor: "#d33",
//    confirmButtonText: "Yes, delete it!"
//}).then((result) => {
//    if (result.isConfirmed) {
//        Swal.fire({
//            title: "Deleted!",
//            text: "Your file has been deleted.",
//            icon: "success"
//        });
//    }
//});