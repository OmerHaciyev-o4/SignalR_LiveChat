function GetUsers(e) {
    setInterval(function () {

        $.ajax({
            url: "/Home/GetAllActiveUsers",
            method: "GET",
            success: function (data) {
                let content = "";

                for (var i = 0; i < data.length; i++) {
                    let item = `
                    <div class="card d-flex flex-row flex-wrap">
                        <img class="card-img-top rounded-circle" style="width:50px;height:50px" src="/images/${data[i].imageUrl}" alt="Card image cap">
                        <h5 class="card-title m-0 text-center h-100" style="width: 73%; padding-top: 12px;">${data[i].userName}</h5>
                    </div>`;
                    content += item;
                }
                $("#activeUsers").html(content);
                console.log(data);
            },
            error: function (err) {
                console.log(err);
            }
        });
        $.ajax({
            url: "/Home/GetAllUsers",
            method: "GET",
            success: function (data) {
                let content = "";

                for (var i = 0; i < data.length; i++) {
                    let style = '';
                    if (data[i].isOnline) {
                        style = 'border:5px solid green;';
                    }
                    else {
                        style = 'border:5px solid red;';
                    }
                    let item = `
                        <div class="card" style="width: 14rem;">
                            <img style="${style}" class="card-img-top" src="/images/${data[i].imageUrl}" alt="Card image cap">
                            <div class="card-body">
                                <h5 class="card-title">${data[i].userName}</h5>
                                <p class="card-text">${data[i].email}</p>
                                <a href="/home/FindCurrentUser/${data[i].id}" class="btn btn-primary">Send</a>
                            </div>
                        </div>`;
                    content += item;
                }
                $("#allUsers").html(content);
                console.log(data);
            },
            error: function (err) {
                console.log(err);
            }
        });
    }, 1000);


}


GetUsers();