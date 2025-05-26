using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Instance
    private static GameManager instance;

    public static GameManager Instance
    {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }
    #endregion

    //원소타입 정보 정의
    public enum ElementType {
        H = 0,
        He = 17,
        Li = 18,
        Be = 19,
        B = 30,
        C = 31,
        N = 32,
        O = 33,
        F = 34,
        Ne = 35,
        Na = 36,
        Mg = 37,
        Al = 48,
        Si = 49,
        P = 50,
        S = 51,
        Cl = 52,
        Ar = 53,
        K = 54,
        Ca = 55,
        Sc = 56,
        Ti = 57,
        V = 58,
        Cr = 59,
        Mn = 60,
        Fe = 61,
        Co = 62,
        Ni = 63,
        Cu = 64,
        Zn = 65,
        Ga = 66,
        Ge = 67,
        As = 68,
        Se = 69,
        Br = 70,
        Kr = 71,
        Rb = 72,
        Sr = 73,
        Y = 74,
        Zr = 75,
        Nb = 76,
        Mo = 77,
        Tc = 78,
        Ru = 79,
        Rh = 80,
        Pd = 81,
        Ag = 82,
        Cd = 83,
        In = 84,
        Sn = 85,
        Sb = 86,
        Te = 87,
        I = 88,
        Xe = 89,
        Cs = 90,
        Ba = 91,
        La = 92,
        Ce = 93,
        Pr = 94,
        Nd = 95,
        Pm = 96,
        Sm = 97,
        Eu = 98,
        Gd = 99,
        Tb = 100,
        Dy = 101,
        Ho = 102,
        Er = 103,
        Tm = 104,
        Yb = 105,
        Lu = 106,
        Hf = 107,
        Ta = 108,
        W = 109,
        Re = 110,
        Os = 111,
        Ir = 112,
        Pt = 113,
        Au = 114,
        Hg = 115,
        Tl = 116,
        Pb = 117,
        Bi = 118,
        Po = 119,
        At = 120,
        Rn = 121,
        Fr = 122,
        Ra = 123,
        Ac = 124,
        Th = 125,
        Pa = 126,
        U = 127,
        Np = 128,
        Pu = 129,
        Am = 130,
        Cm = 131,
        Bk = 132,
        Cf = 133,
        Es = 134,
        Fm = 135,
        Md = 136,
        No = 137,
        Lr = 138,
        Rf = 139,
        Db = 140,
        Sg = 141,
        Bh = 142,
        Hs = 143,
        Mt = 144,
        Ds = 145,
        Rg = 146,
        Cn = 147,
        Nh = 148,
        Fl = 149,
        Mc = 150,
        Lv = 151,
        Ts = 152,
        Og = 153
    }


    public void OnEnable()
    {
        OnInit();
    }

    /// <summary>
    /// 초기 진행 설정 
    /// </summary>
    private void OnInit() {
        Screen.SetResolution(3840, 2160, true);
        Debug.Log("초기 진행 설정 구간");
    }

    /// <summary>
    /// 리셋
    /// </summary>
    public void OnReset() {
        Debug.Log("리셋 설정 구간 ");
    }

    public GameObject eg;





}
