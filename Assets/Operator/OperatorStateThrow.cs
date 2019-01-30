﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorStateThrow : IState<OperatorContext> {

	int count = 600;

	public void ExecuteEntry(OperatorContext context) {
		
		count = 600;
	}

	public void ExecuteUpdate(OperatorContext context) {

		// カウント0で強制的に鉛筆を投げる
		if (count == 0) {
			context.OperatorController.ForceThrowPencil();
			context.ChangeState(context.stateWait);
		}

		// 出目が確定したら待機ステートへ
		if (context.OperatorController.OperatorModel.pencil.Outcome != 0) {
			context.ChangeState(context.stateWait);
		}

		count--;
	}

	public void ExecuteExit(OperatorContext context) {

	}
}