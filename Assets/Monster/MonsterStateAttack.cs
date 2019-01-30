﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モンスターの待機ステート
/// </summary>
public class MonsterStateAttack : IState<MonsterContext> {

	public void ExecuteEntry(MonsterContext context) {
        Debug.Log("[Entry] Monster State : Attack");

        BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour._animator.SetTrigger("AttackTrigger");
    }

	public void ExecuteUpdate(MonsterContext context) {

        if (BattleManager.Instance.ActiveController.OperatorModel.monsterBehaviour._animator.IsInTransition(0))
        {
            BattleManager.Instance.BattleContext.isDone = true;
            context.ChangeState(context.stateIdle);
        }
    }

	public void ExecuteExit(MonsterContext context) {
        var nonActive = BattleManager.Instance.NonActiveController.OperatorModel;
        var active = BattleManager.Instance.ActiveController.OperatorModel;

        nonActive.monsterBehaviour.MonsterModel.hp -=
            active.monsterBehaviour.MonsterModel.skillList[active.pencil.Outcome - 1].power;
        
        Debug.Log("[Exit] Monster State : Attack");
    }
}