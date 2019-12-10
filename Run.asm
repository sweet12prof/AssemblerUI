addi $a0, $zero, 40 #M
addi $a1, $zero, 5 #P
addi $t3, $zero, 0 #answer
addi $a2, $zero, 32 #full Counter
addi $a3, $zero, 1 #startCount
addi $t0, $zero, 1 #LastBitCheck1
addi $t2, $zero, 0
addi $t1, $zero, 0 #StoreTestResult
CheckLastBit: and $t1, $a1, $t0
addi $a3, $a3, 1
beq $t1, $t2, shift
add $t3, $a0, $t3 
shift: srl $a1, $a1, 1
sll $a0, $a0, 1
beq $a3, $a2, beforeEnd
jal CheckLastBit
j end
beforeEnd: jr $ra
end: sw $t3, 100($0)


