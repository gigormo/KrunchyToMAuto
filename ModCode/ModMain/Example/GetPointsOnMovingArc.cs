using System;
using UnityEngine;

namespace KrunchyToMAuto
{
    public class GetPointsOnMovingArc
    {
        private Vector2 leftDown;

        private Vector2 rightUp;

        private float maxR;

        private float angle;

        private bool clockwise = true;

        private const float Deg2Rad = (float)Math.PI / 180f;

        private UnitCtrlBase lastCtrlBase;

        internal GetPointsOnMovingArc(Vector2 leftDown, Vector2 rightUp)
        {
            this.leftDown = leftDown;
            this.rightUp = rightUp;
            float num = (rightUp.x - leftDown.x) / 2f;
            float num2 = (rightUp.y - leftDown.y) / 2f;
            maxR = ((num < num2) ? num : num2);
        }

        internal Vector2 AroundTrajectory()
        {
            return GetPlayerPosiType(SceneType.battle.battleMap.playerUnitCtrl.move.lastPosi);
        }

        private Vector2 GetPlayerPosiType(Vector2 playerPosi)
        {
            return (0f <= playerPosi.x && playerPosi.x <= rightUp.x / 3f) ? ((0f <= playerPosi.y && playerPosi.y <= rightUp.y / 3f) ? new Vector2(rightUp.x / 2f, leftDown.y) : ((!(rightUp.y / 3f < playerPosi.y) || !(playerPosi.y <= rightUp.y * 2f / 3f)) ? new Vector2(leftDown.x, rightUp.y / 2f) : new Vector2(leftDown.x, leftDown.y))) : ((rightUp.x / 3f < playerPosi.x && playerPosi.x <= rightUp.x * 2f / 3f) ? ((0f <= playerPosi.y && playerPosi.y <= rightUp.y / 3f) ? new Vector2(rightUp.x, leftDown.y) : ((!(rightUp.y / 3f < playerPosi.y) || !(playerPosi.y <= rightUp.y * 2f / 3f)) ? new Vector2(leftDown.x, rightUp.y) : new Vector2(rightUp.x / 2f, leftDown.y))) : ((0f <= playerPosi.y && playerPosi.y <= rightUp.y / 3f) ? new Vector2(rightUp.x, rightUp.y / 2f) : ((!(rightUp.y / 3f < playerPosi.y) || !(playerPosi.y <= rightUp.y * 2f / 3f)) ? new Vector2(rightUp.x / 2f, rightUp.y) : new Vector2(rightUp.x, rightUp.y))));
        }

        private int CtrlBaseNineSquareGridPosi(Vector2 ctrlBasePosi)
        {
            if (0f <= ctrlBasePosi.x && ctrlBasePosi.x <= rightUp.x / 3f)
            {
                if (0f <= ctrlBasePosi.y && ctrlBasePosi.y <= rightUp.y / 3f)
                {
                    return 1;
                }

                if (rightUp.y / 3f < ctrlBasePosi.y && ctrlBasePosi.y <= rightUp.y * 2f / 3f)
                {
                    return 4;
                }

                return 7;
            }

            if (rightUp.x / 3f < ctrlBasePosi.x && ctrlBasePosi.x <= rightUp.x * 2f / 3f)
            {
                if (0f <= ctrlBasePosi.y && ctrlBasePosi.y <= rightUp.y / 3f)
                {
                    return 2;
                }

                if (rightUp.y / 3f < ctrlBasePosi.y && ctrlBasePosi.y <= rightUp.y * 2f / 3f)
                {
                    return 5;
                }

                return 8;
            }

            if (0f <= ctrlBasePosi.y && ctrlBasePosi.y <= rightUp.y / 3f)
            {
                return 3;
            }

            if (rightUp.y / 3f < ctrlBasePosi.y && ctrlBasePosi.y <= rightUp.y * 2f / 3f)
            {
                return 6;
            }

            return 9;
        }

        private float GetStartAngle(Vector2 monstPosi, Vector2 playerPosi)
        {
            Vector2 vector = playerPosi - monstPosi;
            float num = Mathf.Atan2(vector.y, vector.x);
            if (0f <= num && (double)num <= Math.PI / 2.0)
            {
                clockwise = true;
            }
            else if (Math.PI / 2.0 < (double)num && (double)num <= Math.PI)
            {
                clockwise = false;
            }
            else if (-Math.PI / 2.0 < (double)num && num < 0f)
            {
                clockwise = false;
            }
            else
            {
                clockwise = true;
            }

            return num;
        }

        private Vector2 FarAway(Vector2 monstPosi, Vector2 playerPosi, float awayDis)
        {
            Vector2 result = OppositePosi(monstPosi, playerPosi, awayDis);
            if (result.x < leftDown.x || result.x > rightUp.x || result.y < leftDown.y || result.y > rightUp.y)
            {
                return RandomNineSquareGridPosi(playerPosi);
            }

            return result;
        }

        private Vector2 OppositePosi(Vector2 monstPosi, Vector2 playerPosi, float r)
        {
            Vector2 normalized = (playerPosi - monstPosi).normalized;
            float num = Vector2.Distance(monstPosi, playerPosi);
            float num2 = r - num;
            return playerPosi + normalized * num2;
        }

        private Vector2 RandomNineSquareGridPosi(Vector2 playerPosi)
        {
            bool flag = CommonTool.Random(0, 2) == 1;
            float x = leftDown.x;
            float x2 = rightUp.x / 3f;
            float x3 = rightUp.x * 2f / 3f;
            float x4 = rightUp.x;
            float y = leftDown.y;
            float y2 = rightUp.y / 3f;
            float y3 = rightUp.y * 2f / 3f;
            float y4 = rightUp.y;
            if (0f <= playerPosi.x && playerPosi.x <= rightUp.x / 3f)
            {
                if (0f <= playerPosi.y && playerPosi.y <= rightUp.y / 3f)
                {
                    if (flag)
                    {
                        return GetGridRandomPosi(new Vector2(x, y2), new Vector2(x2, y3));
                    }

                    return GetGridRandomPosi(new Vector2(x2, y), new Vector2(x3, y2));
                }

                if (rightUp.y / 3f < playerPosi.y && playerPosi.y <= rightUp.y * 2f / 3f)
                {
                    if (flag)
                    {
                        return GetGridRandomPosi(new Vector2(x, y3), new Vector2(x2, y4));
                    }

                    return GetGridRandomPosi(new Vector2(x, y), new Vector2(x2, y2));
                }

                if (flag)
                {
                    return GetGridRandomPosi(new Vector2(x2, y3), new Vector2(x3, y4));
                }

                return GetGridRandomPosi(new Vector2(x, y3), new Vector2(x2, y4));
            }

            if (rightUp.x / 3f < playerPosi.x && playerPosi.x <= rightUp.x * 2f / 3f)
            {
                if (0f <= playerPosi.y && playerPosi.y <= rightUp.y / 3f)
                {
                    if (flag)
                    {
                        return GetGridRandomPosi(new Vector2(x, y), new Vector2(x2, y2));
                    }

                    return GetGridRandomPosi(new Vector2(x3, y), new Vector2(x4, y2));
                }

                if (rightUp.y / 3f < playerPosi.y && playerPosi.y <= rightUp.y * 2f / 3f)
                {
                    if (flag)
                    {
                        return GetGridRandomPosi(new Vector2(x3, y2), new Vector2(x4, y3));
                    }

                    return GetGridRandomPosi(new Vector2(x, y2), new Vector2(x2, y3));
                }

                if (flag)
                {
                    return GetGridRandomPosi(new Vector2(x3, y3), new Vector2(x4, y4));
                }

                return GetGridRandomPosi(new Vector2(x, y3), new Vector2(x2, y4));
            }

            if (0f <= playerPosi.y && playerPosi.y <= rightUp.y / 3f)
            {
                if (flag)
                {
                    return GetGridRandomPosi(new Vector2(x2, y), new Vector2(x3, y2));
                }

                return GetGridRandomPosi(new Vector2(x3, y2), new Vector2(x4, y3));
            }

            if (rightUp.y / 3f < playerPosi.y && playerPosi.y <= rightUp.y * 2f / 3f)
            {
                if (flag)
                {
                    return GetGridRandomPosi(new Vector2(x3, y), new Vector2(x4, y2));
                }

                return GetGridRandomPosi(new Vector2(x3, y3), new Vector2(x4, y4));
            }

            if (flag)
            {
                return GetGridRandomPosi(new Vector2(x3, y2), new Vector2(x4, y3));
            }

            return GetGridRandomPosi(new Vector2(x2, y3), new Vector2(x3, y4));
        }

        private Vector2 GetGridRandomPosi(Vector2 ld, Vector2 ru)
        {
            float x = CommonTool.Random(ld.x, ru.x);
            float y = CommonTool.Random(ld.y, ru.y);
            return new Vector2(x, y);
        }

        internal Vector2 GetPointOnMovingArc(UnitCtrlBase ctrlBase, Vector2 monstPosi, Vector2 playerPosi, float skillRange)
        {
            if (skillRange > maxR)
            {
                skillRange = maxR;
            }

            float num = Vector2.Distance(playerPosi, monstPosi);
            float r = skillRange * 1.1f;
            if (num < skillRange * 0.9f)
            {
                lastCtrlBase = null;
                Vector2 result = OppositePosi(monstPosi, playerPosi, r);
                if (!(result.x < leftDown.x) && !(result.x > rightUp.x) && !(result.y < leftDown.y) && !(result.y > rightUp.y))
                {
                    return result;
                }
            }

            if (lastCtrlBase == null)
            {
                angle = GetStartAngle(monstPosi, playerPosi);
                lastCtrlBase = ctrlBase;
            }
            else if (!lastCtrlBase.Equals(ctrlBase))
            {
                angle = GetStartAngle(monstPosi, playerPosi);
                lastCtrlBase = ctrlBase;
            }

            for (int i = 15; i <= 360; i += 15)
            {
                if (clockwise)
                {
                    angle -= (float)i * ((float)Math.PI / 180f);
                }
                else
                {
                    angle += (float)i * ((float)Math.PI / 180f);
                }

                float x = monstPosi.x + skillRange * Mathf.Cos(angle);
                float y = monstPosi.y + skillRange * Mathf.Sin(angle);
                Vector2 result2 = new Vector2(x, y);
                if (result2.x >= leftDown.x && result2.x <= rightUp.x && result2.y >= leftDown.y && result2.y <= rightUp.y && (IsSameDir(result2.x - monstPosi.x, playerPosi.x - monstPosi.x) || IsSameDir(result2.y - monstPosi.y, playerPosi.y - monstPosi.y)))
                {
                    return result2;
                }
            }

            return AroundTrajectory();
        }

        private bool IsSameDir(float f1, float f2)
        {
            if (f1 > 0f && f2 > 0f)
            {
                return true;
            }

            if (f1 < 0f && f2 < 0f)
            {
                return true;
            }

            return false;
        }
    }
}