# Toy Machine Simulator


## 模擬器主要結構

將 Toy Machine 的各個部分劃分為多個元件，並以一個 Main_controller 控制（send signal）所有元件，
每一個元件都應有一個 PartName_main_control 為主要控制 script（ partname須代換 ），而每個元件的 main_control
會有一個 public 的 get_signal() 函式，向 Main_controller 要求訊號。

### Main_controller 傳送訊號 -> 元件 的方法

假設元件的主要控制 script 名稱為 PartName_main_control
以 gameObject.GetComponentInChildren<PartName_main_control>().get_signal( *signal* );
來傳送訊號給元件，其中 *signal* 即為訊號，有可能為各種型態。

## 元件區分

列出目前有劃分出來的元件：
### Data Base (存memory,register)
	* 主要 script:
		Data_Base
	* 要求訊號型態:
		無
	* 訊號對應:
		直接call裡面函式

### PC
	* 主要 script:
		PC
	* 要求訊號型態:
		無
	* 訊號對應:
		直接call裡面函式

### INPUT
### 七段顯示器
	* 主要 script:
		dis7_main_controll
	* 要求訊號型態:
		int signal[4]	
	* 訊號對應:
		signal[0] 對到 七段顯示器第 0 位，以此類推

### PC 燈號
	* 主要 script:
		PC_light_main_control
	* 要求訊號型態:
		int signal[2]
	* 訊號對應:
		signal[0] 對到 PC 第 0 位， signal[1] 對到 PC 第 1 位 

### Instruction 燈號
	* 主要 script:
		Instr_light_main_control
	* 要求訊號型態:
		int signal[4]
	* 訊號對應:
		signal[0] 對到 Instr_light 第 0 位，以此類推

### OUTPUT
### ADDR 按鈕
	* 主要 script:
		switch_addr_main_control
	* 要求訊號型態:
		不需訊號
	* 訊號對應:
		直接 call get_signal() 會以 int[2,4] 的型態回傳八個 switch 的狀態(開：1 關：0)

### DATA 按鈕
	* 主要 script:
		switch_data_main_control
	* 要求訊號型態:
		不需訊號
	* 訊號對應:
		直接 call get_signal() 會以 int[4,4] 的型態回傳十六個 switch 的狀態(開：1 關：0)

## 附註：
* 有新的元件的話放上面ㄅ
* 多個 object 共享的 script 丟 useful_script 資料夾裡吧
* PC light 和 七段顯示器的測試功能(Upload()函式)都還沒拔掉

case 8


