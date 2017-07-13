<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Welcome </title>

    <!-- Bootstrap Core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'/>
    <link href='https://fonts.googleapis.com/css?family=Merriweather:400,300,300italic,400italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'/>

    <!-- Plugin CSS -->
    <link href="vendor/magnific-popup/magnific-popup.css" rel="stylesheet"/>

    <!-- Theme CSS -->
    <link href="css/creative.min.css" rel="stylesheet"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body id="page-top">

    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">Board of Revenue</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    
                    <li>
                        <a class="page-scroll" href="#about">About</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#services">Services</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#contact">Contact</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#Login">Login</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Search2.aspx">Search</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>

    <header>
        <div class="header-content">
            <div class="header-content-inner">
                <h1 id="homeHeading">Welcome to Board of Revenue</h1>
                <hr/>
                <p>Revenue Board start a service of Question and Answer with there respective department.</p>
                <a href="#about" class="btn btn-primary btn-xl page-scroll">Find Out More</a>
            </div>
        </div>
    </header>

    <section class="bg-primary" id="about">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <h2 class="section-heading">We've got what you need!</h2>
                    <hr class="light"/>
                    <p class="text-faded"></p>
                    <a href="#services" class="page-scroll btn btn-default btn-xl sr-button">Get Started!</a>
                </div>
            </div>
        </div>
    </section>

    <section id="services">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2 class="section-heading">Service</h2>
                    <hr class="primary"/>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="service-box">
                        <i class="fa fa-4x fa-connectdevelop text-primary sr-icons"></i>
                        <h3>Connect</h3>
                        <p class="text-muted">Service help to connect various department</p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="service-box">
                        <i class="fa fa-4x fa-question-circle text-primary sr-icons"></i>
                        <h3>QnA</h3>
                        <p class="text-muted">Service provide Question and Answer faclities to various departments. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="service-box">
                        <i class="fa fa-4x fa-bell-o text-primary sr-icons"></i>
                        <h3>Up to Date</h3>
                        <p class="text-muted">This Service provide up to date faclities between client and servers. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 text-center">
                    <div class="service-box">
                        <i class="fa fa-4x fa-support text-primary sr-icons"></i>
                        <h3>Reliable</h3>
                        <p class="text-muted">Service is easily mantainable and robust that user can experience at his best.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    
    <section id="contact">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <h2 class="section-heading">Let's Get In Touch!</h2>
                    <hr class="primary" />
                    <p>Contact Us <br />
                        Address : Board of Revenue Rajasthan, Todarmal marg, Civil lines, Ajmer
                        <br />
                    </p>
                </div>
                <div class="col-lg-4 col-lg-offset-2 text-center">
                    <i class="fa fa-phone fa-3x sr-contact"></i>
                    <p>0145-2627891</p>
                </div>
                <div class="col-lg-4 text-center">
                    <i class="fa fa-envelope-o fa-3x sr-contact"></i>
                    <p><a href="mailto:bor-rj@nic.in">bor-rj@nic.in</a></p>
                </div>
            </div>
            <div class="row" align="center">
                For more Contact information <br />
                
                <a href="http://landrevenue.rajasthan.gov.in/content/landrevenue/en/board-of-revenue-for-raj-dep/phonelist.html" draggable="true" >Click here</a>
            </div>
        </div>
    </section>
    <section id="Login">
        <div class = "container">
	        <div class="wrapper">
                <script type="text/javascript">
                    var specialKeys = new Array();
                    specialKeys.push(8); //Backspace
                    specialKeys.push(9); //Tab
                    specialKeys.push(32); //space
                    specialKeys.push(46); //Delete
                    specialKeys.push(36); //Home
                    specialKeys.push(35); //End
                    specialKeys.push(37); //Left
                    specialKeys.push(39); //Right
                    function IsAlphaNumeric(e) {
                        var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
                        var ret = ((keyCode == 46) || (keyCode >= 48 && keyCode <= 57) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (keyCode == 32) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
                        document.getElementById("error").style.display = ret ? "none" : "inline";
                        return ret;
                    }

                    function checkPassword(e) {
                        var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
                        var ret = ((keyCode == 46) || (keyCode == 13) || (keyCode >= 48 && keyCode <= 57) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (keyCode == 32) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
                        document.getElementById("error").style.display = ret ? "none" : "inline";
                        return ret;
                    }
                    function convertToUnicode(s) {
                        var se = document.getElementById("text1").nodeValue;
                        alert(se);

                    }

                </script>
                <link href="css/Signin.css" rel="stylesheet"/>
		        <form method="post" name="Login_Form" class="form-signin" runat="server">       
		            <h3 class="form-signin-heading" align="center">Welcome! Please Sign In</h3>
			        <hr class="colorgraph"/><br/>
			  
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Enter Email" onkeypress="return IsAlphaNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                    <span id="error" style="color: Red; display: none">* Special Characters not allowed</span>
			        <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" onkeypress="return checkPassword(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="CheckBox1" Text="Remember me" runat="server" CssClass="checkbox" />
                        </label>
                    </div>
			        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" />
		        </form>			
	        </div>
        </div>
    </section>

    <!-- jQuery -->
    <script src="vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src="vendor/scrollreveal/scrollreveal.min.js"></script>
    <script src="vendor/magnific-popup/jquery.magnific-popup.min.js"></script>

    <!-- Theme JavaScript -->
    <script src="js/creative.min.js"></script>

</body>

</html>
