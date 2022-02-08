package OldFiles;


import java.awt.AWTException;
import java.awt.Dimension;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.Toolkit;
import java.awt.image.BufferedImage;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.net.*;

public class ScreenVideo1D {
	@SuppressWarnings("static-access")
	public static void main(String[] args) {
		//ѯ�ʿ������
		int choice = JOptionPane.showConfirmDialog(null, "���Ա��ؼ�س��������", "��ʾ", JOptionPane.YES_NO_OPTION);
		System.out.println("��������!");
		//�ж�
		if(choice==1)	{
			//�˳�
			return;
		}		
		String localip = "";
		try{
			//��ȡIP
			InetAddress ip=null;
			ip = ip.getLocalHost();
			localip = ip.getHostAddress();
			System.out.println("IP��ȡ�ɹ�");
		}
		catch(Exception e)
		{
			//��ȡʧ�ܣ���ʾ���󲢽���
			JOptionPane.showConfirmDialog(null, "���������˲��ɽ���Ĵ���", "����", JOptionPane.OK_OPTION);
			System.out.println("IP��ȡʧ��");
			e.printStackTrace();
		}
		
		//����������ʾ��
		String result = JOptionPane.showInputDialog("������IP��ַ",localip);
		System.out.println("IP������");
		if(result.equals(localip)){
			JOptionPane.showConfirmDialog(null, "������ʼ���", "����", JOptionPane.OK_OPTION);
			System.out.println("IP��ȷ,������ʼ���,����");
		}else{
			JOptionPane.showConfirmDialog(null, "����ʧ��"+"�쳣���׳�", "�쳣", JOptionPane.OK_OPTION);
			System.out.println("IPʧ��,����ʧ�ܣ��쳣���׳�");
		}
		try{
			//���봰��
			JFrame c1 = new JFrame();
			c1.setVisible(true);
			System.out.println("���봰����");
			//������С
			c1.setSize(1000, 850);
			System.out.println("������С��");
			int rtu = c1.getWidth();
			int rty = c1.getHeight();
			//��������
			c1.setTitle("���-��Ļʵʱ���("+rtu+","+rty+")");
			System.out.println("����������");
			//������ʼλ��
			c1.setLocationRelativeTo(null);
			System.out.println("������ʼλ����");
			//�ö�
			c1.setAlwaysOnTop(true);
			System.out.println("�����ö�����");
			//�ر�ʱ�ͷ��ڴ�
			c1.setDefaultCloseOperation(c1.EXIT_ON_CLOSE);
			System.out.println("����������");
			//���Ƽ�������Ȼ�ȡȨ��,����Tool����
			Toolkit arTool = Toolkit.getDefaultToolkit();
			System.out.println("��ȡȨ����");
			//��ȡ�Է�����Ļ��С
			Dimension size =  arTool.getScreenSize();
			double width = size.getWidth();//��
			double height = size.getHeight();//��
			System.out.println("��ȡ�Է���Ļ��С��");
			//���������
			JLabel ca1 = new JLabel();
			System.out.println("�����������");
			//������
			c1.add(ca1);
			System.out.println("��������");
			//����
			System.out.println("������");
			try{
				//�ٻ�������
				Robot r1 = new Robot();
				System.out.println("�ٻ���������");
				//���������
				Rectangle re1 = new Rectangle(c1.getWidth(),0,(int)width,(int)height);
				System.out.println("�������������");
				int stu = 0;
				int sui = 0;
				int suo = 0;
				while(stu==0){
					//����
					BufferedImage img1 = r1.createScreenCapture(re1);
					while(sui==0){
						System.out.println("������");	
						sui=1;
						System.out.println("�������");
						System.out.println("��������������");	
						System.out.println("�˳������ͷ������ڴ�");
					}					
					//�����Ļ
					ca1.setIcon(new ImageIcon(img1));
					while(suo==0){
						System.out.println("�����Ļ��");								
						suo=1;
						System.out.println("�����Ļ���");
						System.out.println("�����Ļ����������");
						System.out.println("�˳������ͷ������ڴ�");
					}	
				}
			}
			catch (AWTException e){
				System.out.println("δ֪���쳣");
				e.printStackTrace();
			}
		}
		catch(RuntimeException e){
			e.printStackTrace();
			System.out.println("δ֪���쳣");
		}		
	}
}
