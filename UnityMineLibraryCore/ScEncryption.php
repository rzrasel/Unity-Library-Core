<?php
function decryptRJ256($encrypted, $key, $iv)
{
    //PHP strips "+" and replaces with " ", but we need "+" so add it back in...
    $encrypted = str_replace(' ', '+', $encrypted);

    //get all the bits
    $key = base64_decode($key);
    $iv = base64_decode($iv);
    $encrypted = base64_decode($encrypted);

    $rtn = mcrypt_decrypt(MCRYPT_RIJNDAEL_256, $key, $encrypted, MCRYPT_MODE_CBC, $iv);
    $rtn = unpad($rtn);
    return($rtn);
}

//removes PKCS7 padding
function unpad($value)
{
    $blockSize = mcrypt_get_block_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_CBC);
    $packing = ord($value[strlen($value) - 1]);
    if($packing && $packing < $blockSize)
    {
        for($P = strlen($value) - 1; $P >= strlen($value) - $packing; $P--)
        {
            if(ord($value{$P}) != $packing)
            {
                $packing = 0;
            }
        }
    }

    return substr($value, 0, strlen($value) - $packing); 
}
function genIvR()
{
    $efforts = 0;
    $maxEfforts = 50;
    $wasItSecure = false;

    do
    {
        $efforts+=1;
        $iv = openssl_random_pseudo_bytes(32, $wasItSecure);
        if($efforts == $maxEfforts){
            throw new Exception('Unable to genereate secure iv.');
            break;
        }
    } while (!$wasItSecure);
	/*$method = 'aes-256-cbc';
	$ivlen = openssl_cipher_iv_length($method);*/
	/*$cipher = mcrypt_module_open(MCRYPT_RIJNDAEL_256, '', 'ctr', '');
	$ivlen = mcrypt_enc_get_iv_size($cipher);
	echo $ivlen;
	$isCryptoStrong = false; // Will be set to true by the function if the algorithm used was cryptographically secure
	$iv = openssl_random_pseudo_bytes($ivlen, $isCryptoStrong);*/

    return base64_encode($iv);
}
function genIv()
{
	$iv_size = mcrypt_get_iv_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_CBC);
	$iv = mcrypt_create_iv(mcrypt_get_iv_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_CBC), MCRYPT_RAND);
	return base64_encode($iv);
}
function genKey($argPassword)
{
	$cipher = MCRYPT_RIJNDAEL_256;  // = AES-256
	$mode   = MCRYPT_MODE_CBC;
	$keylen = mcrypt_get_key_size($cipher, $mode);

	$salt   = mcrypt_create_iv( $keylen, MCRYPT_DEV_URANDOM );
	$iterations = 10000;  // higher = slower; make this as high as you can tolerate

	$key = hash_pbkdf2( 'sha256', $argPassword, $salt, $iterations, $keylen, true );
	return base64_encode($key);
}
function generateRandomString($length = 32) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
	//return substr(str_shuffle(str_repeat($x='0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ', ceil($length/strlen($x)) )),1,$length);
}
?>
<?php
$key = "NQDB8bOyKFPe+995UzWVQgNiZQe/RDshyatPvxm0rv8=";
$iv = "J1gBWKbNVsjEsV+KiyvkhYDhLSGt/QFHmienXk6G6k8=";
$encData = "zquOFjNxhFlQyrANenas9I2bITu0dqvtkuzz+lPDj98=";
echo "<br />";
echo decryptRJ256($encData, $key, $iv);
echo "<br />";
echo "<br />";
$pasVal = "Rz Rasel";
$pasVal = preg_replace('/\s+/', '', $pasVal);
echo "<br />";
echo "Pass: " . $pasVal;
$key = $pasVal . generateRandomString(32 - strlen($pasVal));
$key = str_shuffle($key);
$key = str_shuffle($key);
echo "<br />";
echo "Key: ";
echo "<br />";
echo genKey($key);
echo "<br />";
echo "IV: ";
echo "<br />";
echo genIv();
echo "<br />";
/*echo decryptRJ256($key, $iv, $encData);
echo "<br />";
echo genIv();
$cipher = mcrypt_module_open(MCRYPT_RIJNDAEL_256, '', 'ctr', '');
$iv_size = mcrypt_enc_get_iv_size($cipher);
echo base64_encode(generateRandomString());
echo "<br />";
echo "<br />";
$key = "testOff";
$iv_size = mcrypt_get_iv_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_CBC);
$iv = mcrypt_create_iv(mcrypt_get_iv_size(MCRYPT_RIJNDAEL_256, MCRYPT_MODE_CBC), MCRYPT_RAND);
//$iv = base64_encode($iv . mcrypt_encrypt(MCRYPT_RIJNDAEL_256, $key, $toEncrypt, MCRYPT_MODE_CBC, $iv));
echo $iv_size;
echo "<br />----";
echo $iv;
echo "<br />--openssl_random_pseudo_bytes";
echo base64_encode(openssl_random_pseudo_bytes(32));
echo "<br />";*/
?>
<?php
/*$password = "tttalsjdfaljf";
$cipher = MCRYPT_RIJNDAEL_128;  // = AES-256
$mode   = MCRYPT_MODE_CBC;
$keylen = mcrypt_get_key_size( $cipher, $mode );

$salt   = mcrypt_create_iv( $keylen, MCRYPT_DEV_URANDOM );
$iterations = 10000;  // higher = slower; make this as high as you can tolerate

$key = hash_pbkdf2( 'sha256', $password, $salt, $iterations, $keylen, true );
echo "Key: <br />";
echo base64_encode($key);
echo "<br />";*/
/*
key = z9K7h0U6KBDhZcCDah5ZmiSTZ+6ULoRTEV+90sUhqy0=
iv = ZufjD+VHDqqOeJNN1rGs6d7P0LqouV0WdKAIdvi9BWY=
data = wywY1LZrvNvhDe4f7rs6guS/5iYMfMaUzC5SjmGEALg=
*/
//https://stackoverflow.com/questions/26273815/two-takes-on-php-two-way-encryption-which-one-is-preferable
?>