function convert_to_unicode()

{



    var array_one = new Array(

    "ñ"  ,    "॰" ,

    "Q\+Z"  ,    "QZ\+" ,

    "sas"  ,    "sa" ,

    "aa"  ,    "a" ,

    "¼Z"  ,    "र्द्ध" ,

    "ZZ"  ,    "Z" ,

    "\‘"  ,    "\"" ,

    "\’"  ,    "\"" ,

    "\“"  ,    "\'" ,

    "\”"  ,    "\'" ,

    "å"  ,    "०" ,

    "ƒ"  ,    "१" ,

    "\„"  ,    "२" ,

    "…"  ,    "३" ,

    "†"  ,    "४" ,

    "‡"  ,    "५" ,

    "\ˆ"  ,    "६" ,

    "‰"  ,    "७" ,

    "Š"  ,    "८" ,

    "\‹"  ,    "९" ,

    "¶+"  ,    "फ़्" ,

    "d+"  ,    "क़" ,

    "[+k"  ,    "ख़" ,

    "[+"  ,    "ख़्" ,

    "x+"  ,    "ग़" ,

    "T+"  ,    "ज़्" ,

    "t+"  ,    "ज़" ,

    "M+"  ,    "ड़" ,

    "\<+"  ,    "ढ़" ,

    "Q+"  ,    "फ़" ,

    "\;+"  ,    "य़" ,

    "j+"  ,    "ऱ" ,

    "u+"  ,    "ऩ" ,

    "Ùk"  ,    "त्त" ,

    "Ù"  ,    "त्त्" ,

    "ä"  ,    "क्त" ,

    "–"  ,    "दृ" ,

    "—"  ,    "कृ" ,

    "é"  ,    "न्न" ,

    "™"  ,    "न्न्" ,

    "\=kk"  ,    "\=k" ,

    "f\=k"  ,    "f\=" ,

    "à"  ,    "ह्न" ,

    "á"  ,    "ह्य" ,

    "â"  ,    "हृ" ,

    "ã"  ,    "ह्म" ,

    "ºz"  ,    "ह्र" ,

    "º"  ,    "ह्" ,

    "í"  ,    "द्द" ,

    "\{k"  ,    "क्ष" ,

    "\{"  ,    "क्ष्" ,

    "f\="  ,    "त्रि" ,

    "\=k"  ,    "त्र" ,

    "\«"  ,    "त्र्" ,

    "Nî"  ,    "छ्य" ,

    "Vî"  ,    "ट्य" ,

    "Bî"  ,    "ठ्य" ,

    "Mî"  ,    "ड्य" ,

    "\<î"  ,    "ढ्य" ,

    "|"  ,    "द्य" ,

    "K"  ,    "ज्ञ" ,

    "}"  ,    "द्व" ,

    "J"  ,    "श्र" ,

    "Vª"  ,    "ट्र" ,

    "Mª"  ,    "ड्र" ,

    "\>ª"  ,    "ढ्र" ,

    "Nª"  ,    "छ्र" ,

    "Ø"  ,    "क्र" ,

    "Ý"  ,    "फ्र" ,

    "nzZ"  ,    "र्द्र" ,

    "æ"  ,    "द्र" ,

    "ç"  ,    "प्र" ,

    "Á"  ,    "प्र" ,

    "xz"  ,    "ग्र" ,

    "#"  ,    "रु" ,

    ":"  ,    "रू" ,

    "v‚"  ,    "ऑ" ,

    "vks"  ,    "ओ" ,

    "vkS"  ,    "औ" ,

    "vk"  ,    "आ" ,

    "v"  ,    "अ" ,

    "b±"  ,    "ईं" ,

    "Ã"  ,    "ई" ,

    "bZ"  ,    "ई" ,

    "b"  ,    "इ" ,

    "mQ"  ,    "ऊ" ,

    "m"  ,    "उ" ,

    "Å"  ,    "ऊ" ,

    "\,s"  ,    "ऐ" ,

    "\,"  ,    "ए" ,

    "½"  ,    "ऋ" ,

    "ô"  ,    "क्क" ,

    "d"  ,    "क" ,

    "Dk"  ,    "क" ,

    "D"  ,    "क्" ,

    "£"  ,    "र्f" ,

    "[k"  ,    "ख" ,

    "["  ,    "ख्" ,

    "x"  ,    "ग" ,

    "Xk"  ,    "ग" ,

    "X"  ,    "ग्" ,

    "Ä"  ,    "घ" ,

    "?k"  ,    "घ" ,

    "?"  ,    "घ्" ,

    "³"  ,    "ङ" ,

    "p"  ,    "च" ,

    "Pk"  ,    "च" ,

    "P"  ,    "च्" ,

    "N"  ,    "छ" ,

    "t"  ,    "ज" ,

    "Tk"  ,    "ज" ,

    "T"  ,    "ज्" ,

    "\>"  ,    "झ" ,

    "÷"  ,    "झ्" ,

    "¥"  ,    "ञ" ,

    "ê"  ,    "ट्ट" ,

    "ë"  ,    "ट्ठ" ,

    "V"  ,    "ट" ,

    "B"  ,    "ठ" ,

    "ì"  ,    "ड्ड" ,

    "ï"  ,    "ड्ढ" ,

    "M+"  ,    "ड़" ,

    "\<+"  ,    "ढ़" ,

    "M"  ,    "ड" ,

    "\<"  ,    "ढ" ,

    "\.k"  ,    "ण" ,

    "\."  ,    "ण्" ,

    "r"  ,    "त" ,

    "Rk"  ,    "त" ,

    "R"  ,    "त्" ,

    "Fk"  ,    "थ" ,

    "F"  ,    "थ्" ,

    "n"  ,    "द" ,

    "\/"  ,    "ध" ,

    "èk"  ,    "ध" ,

    "è"  ,    "ध्" ,

    "Ë  "  ,    "ध्" ,

    "u"  ,    "न" ,

    "Uk"  ,    "न" ,

    "U"  ,    "न्" ,

    "iQ"  ,    "फ" ,

    "i"  ,    "प" ,

    "Ik"  ,    "प" ,

    "I"  ,    "प्" ,

    "¶"  ,    "फ्" ,

    "c"  ,    "ब" ,

    "Ck"  ,    "ब" ,

    "C"  ,    "ब्" ,

    "Hk"  ,    "भ" ,

    "H"  ,    "भ्" ,

    "e"  ,    "म" ,

    "Ek"  ,    "म" ,

    "E"  ,    "म्" ,

    "\;"  ,    "य" ,

    "\¸"  ,    "य्" ,

    "j"  ,    "र" ,

    "y"  ,    "ल" ,

    "Yk"  ,    "ल" ,

    "Y"  ,    "ल्" ,

    "G"  ,    "ळ" ,

    "oQ"  ,    "क" ,

    "o"  ,    "व" ,

    "Ok"  ,    "व" ,

    "O"  ,    "व्" ,

    "\'k"  ,    "श" ,

    "\'"  ,    "श्" ,

    "\"k"  ,    "ष" ,

    "\""  ,    "ष्" ,

    "l"  ,    "स" ,

    "Lk"  ,    "स" ,

    "L"  ,    "स्" ,

    "g"  ,    "ह" ,

    "È"  ,    "ीं" ,

    "z"  ,    "्र" ,

    "Ì"  ,    "द्द" ,

    "Í"  ,    "ट्ट" ,

    "Î"  ,    "ट्ठ" ,

    "Ï"  ,    "ड्ड" ,

    "Ñ"  ,    "कृ" ,

    "Ò"  ,    "भ" ,

    "Ó"  ,    "्य" ,

    "Ô"  ,    "ड्ढ" ,

    "Ö"  ,    "झ्" ,

    "Ø"  ,    "क्र" ,

    "Ù"  ,    "त्त्" ,

    "Ük"  ,    "श" ,

    "Ü"  ,    "श्" ,

    "¼"  ,    "द्ध" ,

    "\‚"  ,    "ॉ" ,

    "¨"  ,    "ो" ,

    "ks"  ,    "ो" ,

    "©"  ,    "ौ" ,

    "kS"  ,    "ौ" ,

    "k"  ,    "ा" ,

    "h"  ,    "ी" ,

    "q"  ,    "ु" ,

    "w"  ,    "ू" ,

    "\`"  ,    "ृ" ,

    "s"  ,    "े" ,

    "¢"  ,    "े" ,

    "S"  ,    "ै" ,

    "a"  ,    "ं" ,

    "¡"  ,    "ँ" ,

    "%"  ,    "ः" ,

    "W"  ,    "ॅ" ,

    "•"  ,    "ऽ" ,

    "·"  ,    "ऽ" ,

    "∙"  ,    "ऽ" ,

    "·"  ,    "ऽ" ,

    "~j"  ,    "्र" ,

    "\\"  ,    "?" ,

    "+"  ,    "़" ,

    " ः"  ,    ":" ,

    "^"  ,    "\‘" ,

    "*"  ,    "\’" ,

    "Þ"  ,    "\“" ,

    "ß"  ,    "\”" ,

    "¾"  ,    "=" ,

    "&"  ,    "-" ,

    "¿"  ,    "{" ,

    "À"  ,    "}" ,

    "A"  ,    "।" ,

    "-"  ,    "." ,

    "Œ"  ,    "॰" ,

    "]"  ,    "\," ,

    "~"  ,    "्" ,

    "्ा" ,    "" ,

    "@"  ,    "\/" ,

    "ाे"  ,    "ो" ,

    "ाॅ"  ,    "ॉ" ,



    "अौ"  ,    "औ" ,

    "अो"  ,    "ओ" ,

    "आॅ"  ,    "ऑ"    )   





    //**********************************************



    var array_one_length = array_one.length ;



    var modified_substring = document.getElementById("DynamicTextBox").value  ;



    modified_substring = modified_substring.replace( /([ZzsSqwa¡`]+)Q/g , "Q$1" )

	

	

    Replace_Symbols( ) ;

	



    modified_substring = modified_substring.replace( /([ेैुूं]+)्र/g , "्र$1" ) ;

    modified_substring = modified_substring.replace( /ं([ाेैुू]+)/g , "$1ं" ) ;

	

    modified_substring = modified_substring.replace( /([f])([कखगघङचछजझञटठडड़ढढ़णतथदधनपफबभमयरलवशषसहक्ष])/g , "$2$1" ) ;



    modified_substring = modified_substring.replace( /([f])(्)([कखगघङचछजझञटठडड़ढढ़णतथदधनपफबभमयरलवशषसहक्ष])/g , "$2$3$1" ) ;

    

    modified_substring = modified_substring.replace( /([f])(्)([कखगघङचछजझञटठडड़ढढ़णतथदधनपफबभमयरलवशषसहक्ष])/g , "$2$3$1" ) ;



    modified_substring = modified_substring.replace( /f/g , "ि") ;

    

	

    modified_substring = modified_substring.replace( /±/g , "Zं" ) ;

    modified_substring = modified_substring.replace( /([कखगघङचछजझञटठडड़ढढ़णतथदधनपफबभमयरलवशषसहक्ष])([़ािीुूृेैोौं]*)[Z]/g , "र्$1$2" ) ;

	

	

    processed_text = modified_substring ;

		

    document.getElementById("unicode_text").value = processed_text  ;



    // --------------------------------------------------





    function Replace_Symbols( )



    {



        //substitute array_two elements in place of corresponding array_one elements



        if ( modified_substring != "" )  // if stringto be converted is non-blank then no need of any processing.

        {

            for ( input_symbol_idx = 0;   input_symbol_idx < array_one_length-1;    input_symbol_idx = input_symbol_idx + 2 )



            { 

                //******************************************************

                idx = 0  ;  // index of the symbol being searched for replacement



                while (idx != -1 ) //while-00

                {



                    modified_substring = modified_substring.replace( array_one[ input_symbol_idx ] , array_one[input_symbol_idx+1] )

                    idx = modified_substring.indexOf( array_one[input_symbol_idx] )



                } // end of while-00 loop



            } // end of for loop





        } // end of IF  statement  meant to  supress processing of  blank  string.



    } // end of the function  Replace_Symbols



} // end of convert_to_unicode function