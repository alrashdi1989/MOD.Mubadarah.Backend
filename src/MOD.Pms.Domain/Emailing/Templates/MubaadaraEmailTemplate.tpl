<!DOCTYPE html>
<html dir="rtl" w>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Project Management System</title>
   <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            display: flex;
            flex-direction: column;
            align-items: center;
	 
        }
        .header, .footer {
            background-color: #333;
            color: #fff;
            padding: 20px;
            text-align: center;
            width: 40%;
            margin-top: 20px;
            border-radius: 10px;
        }
        .content {
            width: 40%;
            margin-top: 20px;
        }
        .section {
            background-color: #fff;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .section h2 {
            margin-top: 0;
        }
        .task {
            background-color: #e7f3fe;
            padding: 15px;
            margin-bottom: 10px;
            border-left: 5px solid #0056b3;
            border-radius: 5px;
        }
    </style>
</head>
<body>

    <div class="header">
        <h1>{{model.title}}</h1>
    </div>

    <div class="content">

        <div  align="center">
           
            <img src = "https://mamsgtzapp01/test/newLogo.png" width = "350" height = "200" />
        </div>

        <div class="section" id="tasks">

            <div class="section">
                <h3>{{model.name}}: {{model.mubaadaraname}}</h3>
            </div>
            <div class="section">
                <h3>{{model.type}}: {{model.mubaadaratype}}</h3>
            </div>
            <div class="section">
                <h3>{{model.messagetype}}: {{model.message}}</h3>
            </div>
        </div>

    </div>

  <div class="footer">
        <p>https://motabie/
<br />
pmis@mod.saf/300203
</p>
    </div>


</body>
</html>
